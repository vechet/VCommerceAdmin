using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Drawing.Imaging;
using System.Drawing;
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

        public static void Convert4SizeImage(string filePath, byte[] photo)
        {
            decimal[] pSizes = { 50M, 150M, 400M, 1000M };
            foreach (var pSize in pSizes)
            {
                var ps = Convert.ToInt32(pSize);
                var buffer = ResizeImage(pSize, pSize, photo);
                using (var stream = new MemoryStream(buffer, 0, buffer.Length))
                {
                    var image = Image.FromStream(stream, true);
                    image.Save(string.Format("{0}-{1}x{2}.jpg", filePath, ps, ps), ImageFormat.Jpeg);
                }
            }
        }

        public static byte[] ResizeImage(decimal width, decimal height, byte[] image)
        {
            if (image == null) return null;
            var stream = new MemoryStream(image);
            var image2 = Image.FromStream(stream, true);
            var bitmapImage = (Bitmap)(image2);

            var imageWidth = image2.Width;
            var imageHeight = image2.Height;
            var widthMultiple = width / imageWidth;
            var heightMultiple = height / imageHeight;
            if (widthMultiple > heightMultiple)
            {
                width = imageWidth * heightMultiple;
            }
            else
            {
                height = imageHeight * widthMultiple;
            }


            Bitmap newBmp = new Bitmap(Convert.ToInt32(width), Convert.ToInt32(height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            newBmp.SetResolution(72, 72);
            Graphics newGraphic = Graphics.FromImage(newBmp);
            newGraphic.Clear(Color.White);
            newGraphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            newGraphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            newGraphic.DrawImage(bitmapImage, 0, 0, Convert.ToInt32(width), Convert.ToInt32(height));

            MemoryStream ms = new MemoryStream();
            newBmp.Save(ms, ImageFormat.Jpeg);
            byte[] bmpBytes = ms.ToArray();
            return bmpBytes;
        }
    }
}