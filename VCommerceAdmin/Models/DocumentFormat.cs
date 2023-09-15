namespace VCommerceAdmin.Models;

public partial class DocumentFormat
{
    public int Id { get; set; }

    /// <summary>
    /// 1 : Purchased, 2 : SaleReturn, 3 : SaleChanged, 4 : Transfer, 5 : AdjustQty, 6 : AdjustCost, 7 : Sale, 8 : PurchaseReturn
    /// </summary>
    public string Type { get; set; } = null!;

    public string? Prefix { get; set; }

    public string? Suffix { get; set; }

    public int Length { get; set; }

    public bool IsAutoGenerate { get; set; }

    public string? FirstFooterOne { get; set; }

    public string? FirstFooterTwo { get; set; }

    public string? FirstFooterThree { get; set; }

    public string? FirstRemark { get; set; }

    public string? SecondFooterOne { get; set; }

    public string? SecondFooterTwo { get; set; }

    public string? SecondFooterThree { get; set; }

    public string? SecondRemark { get; set; }

    public string? FirstPrintDisplay { get; set; }

    public string? FirstPrintFileName { get; set; }

    public string? SecondPrintDisplay { get; set; }

    public string? SecondPrintFileName { get; set; }

    public bool IsDuplicate { get; set; }

    public bool IsAllowToUseMemo { get; set; }

    public string? TableName { get; set; }

    public string? ColumnName { get; set; }

    public string? TransactionType { get; set; }

    public string? StoreId { get; set; }

    public bool IsEditable { get; set; }

    public bool IsSeparateByStore { get; set; }

    public bool IsSeparatePrefixAndSuffixByStore { get; set; }

    public string? Name { get; set; }

    public bool? IsAllowToUseEmail { get; set; }

    public string? FirstFooterFour { get; set; }

    public string? SecondFooterFour { get; set; }

    public string? TransactionTypeColumnName { get; set; }

    public bool? IsPrintable { get; set; }
}