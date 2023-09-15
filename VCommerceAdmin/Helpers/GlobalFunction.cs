﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Cryptography;
using System.Text;
using VCommerceAdmin.Data;
using VCommerceAdmin.Models;

namespace VCommerceAdmin.Helpers
{
    public class GlobalFunction
    {
        public static DateTime GetCurrentDateTime()
        {
            var now = DateTime.Now;
            var local = TimeZoneInfo.Local;
            var destinationTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            return TimeZoneInfo.ConvertTime(now, local, destinationTimeZone);
        }

        public static object RenderErrorMessageFromState(ModelStateDictionary modelState)
        {
            return new
            {
                error = "Info(s):\n" + string.Join("\n- ", modelState.Values
                                      .SelectMany(x => x.Errors)
                                       .Select(x => x.ErrorMessage))
            };
        }

        public static string GetUserName(int userId, VcommerceContext db = null)
        {
            //if (db == null)
            //{
            //    db = new VcommerceContext();
            //}
            //var account = db.UserAccounts.Find(userId);
            //return account != null ? account.UserName : "";
            return "Vechet Dev";
        }

        public static int GetCurrentUserId(VcommerceContext db = null, string token = "")
        {
            //if (db == null)
            //{
            //    db = new VcommerceContext();
            //}
            //var userIdList = db.UserAccountTokens.Where(x => x.Token == token).Select(x => x.UserAccountId).ToList();
            //var currentUser = db.UserAccounts.Where(x => userIdList.Contains(x.Id)).ToList();
            //return currentUser[0].Id;
            return 1;
        }

        public static string Encrypt(string clearText)
        {
            var EncryptionKey = "SmartSolutions";
            var clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            var EncryptionKey = "SmartSolutions";
            cipherText = cipherText.Replace(" ", "+");
            var cipherBytes = Convert.FromBase64String(cipherText);
            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public static void RecordErrorLog(string moduleName, Exception error, VcommerceContext db)
        {
            try
            {
                var currentUserId = GetCurrentUserId();
                var currentDateTime = GetCurrentDateTime();
                var errorString = error.Message + "\n" + error.StackTrace;

                var errorReport = new ErrorReport
                {
                    ModuleName = moduleName,
                    Message = string.Format("Project Name: {0}\nUser Name: {1}\nError Date: {2}\n\n{3}", "VCommerce", GetUserName(currentUserId), currentDateTime, errorString),
                    CreatedBy = currentUserId,
                    CreatedDate = GetCurrentDateTime()
                };
                db.ErrorReports.Add(errorReport);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}