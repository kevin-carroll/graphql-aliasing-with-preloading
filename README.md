## Sample Query

```graphql
query {
  getInvoice(invoiceId:"ABC123") {
    id
    invoiceDate
    
  	largeItems: items(minDollarValue: 30) {
      label
      value
    }
    
    allItems: items(minDollarValue: 5) {
      label
      value
    }
  }
}
```
