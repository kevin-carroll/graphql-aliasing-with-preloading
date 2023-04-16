namespace preloading_with_aliases_example.Controllers
{
    using GraphQL.AspNet.Attributes;

    public class Invoice
    {
        public string Id { get; set; }

        public DateTime InvoiceDate { get; set; }

        [GraphField("items")]
        public List<InvoiceItem> Items(decimal minDollarValue)
        {
            return this.AllItems
                .Where(x => x.Value >= minDollarValue)
                .ToList();
        }

        [GraphSkip]
        public List<InvoiceItem> AllItems { get; set; }
    }
}
