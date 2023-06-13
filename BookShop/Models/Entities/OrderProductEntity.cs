﻿namespace BookShop.Models.Entities;

public class OrderProductEntity : BaseEntity
{
    public Guid OrderId { get; init; }
    public Guid ProductId { get; init; }
    public int Amount { get; set; }
    public ProductEntity Product { get; set; }

}
