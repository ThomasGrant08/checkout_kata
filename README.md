# Checkout Kata

A C# implementation of Checkout Kata, built with .NET 10.

## Overview

This kata simulates a supermarket checkout system that supports:
- Scanning items by SKU
- Individual item pricing
- Multi-item special offer pricing (e.g. "3 for 130")

## Pricing Rules

| SKU | Unit Price | Special Offer |
| - | - | - |
| A | 50 | 3 for 130 |
| B | 30 | 2 for 45 |
| C | 20 | - |
| D | 15 | - |

## Usage

```csharp
var products = new Dictionary<string, int>
{
    { "A", 50 },
    { "B", 30 },
    { "C", 20 },
    { "D", 15 }
};

var offerRules = new Dictionary<string, OfferRule>
{
    { "A", new OfferRule("A", 3, 130) },
    { "B", new OfferRule("B", 2, 45) }
};

ICheckout checkout = new Checkout(products, offerRules);

checkout.Scan("A");
checkout.Scan("A");
checkout.Scan("A");
checkout.Scan("B");

int total = checkout.GetTotalPrice(); // 160
```

## Running Tests

```
dotnet test
```

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
