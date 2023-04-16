## Sample Query

```graphql
# Write your query or mutation here
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