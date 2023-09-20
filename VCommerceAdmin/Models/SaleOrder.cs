using System;
using System.Collections.Generic;

namespace VCommerceAdmin.Models;

public partial class SaleOrder
{
    public int Id { get; set; }

    public string? SaleOrderNo { get; set; }

    public string? ReferenceNo { get; set; }

    public int StoreId { get; set; }

    public int CustomerId { get; set; }

    /// <summary>
    /// Amount before discount invoice and deposit
    /// </summary>
    public decimal TotalAmount { get; set; }

    public decimal TotalItemDiscountAmount { get; set; }

    public decimal TotalAmountAfterItemDiscount { get; set; }

    public decimal DiscountPercentage { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal TotalAmountAfterDiscount { get; set; }

    public decimal VatPercentage { get; set; }

    public decimal VatAmount { get; set; }

    /// <summary>
    /// Amount after discount invoice
    /// </summary>
    public decimal GrandTotalAmount { get; set; }

    public decimal DepositAmount { get; set; }

    public decimal RemainAmount { get; set; }

    public int PaymentMethodId { get; set; }

    public string? PaymentReferenceNo { get; set; }

    public DateTime TransactionDate { get; set; }

    public DateTime SaleDate { get; set; }

    public bool IsSeenDueDateNotification { get; set; }

    /// <summary>
    /// Pending, Sale, Deleted
    /// </summary>
    public short TransactionFlag { get; set; }

    /// <summary>
    /// 1= Pending, 2 = Purchased, 3 = Reject
    /// </summary>
    public string? Memo { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int Version { get; set; }

    public int? QuotationId { get; set; }

    public int? ClosedBy { get; set; }

    public DateTime? ClosedDate { get; set; }

    public string? InternalMemo { get; set; }

    public int CurrencyId { get; set; }

    public decimal ExchangeRate { get; set; }

    public int GenerateId { get; set; }

    public bool IsReversed { get; set; }

    public short? TransactionStage { get; set; }

    public int? CustomerShippingAddressId { get; set; }

    public virtual Currency Currency { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual CustomerShippingAddress? CustomerShippingAddress { get; set; }

    public virtual PaymentMethod PaymentMethod { get; set; } = null!;

    public virtual ICollection<SaleOrderDetail> SaleOrderDetails { get; set; } = new List<SaleOrderDetail>();

    public virtual Store Store { get; set; } = null!;
}
