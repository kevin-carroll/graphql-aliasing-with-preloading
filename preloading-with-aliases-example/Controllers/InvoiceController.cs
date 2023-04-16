namespace preloading_with_aliases_example.Controllers
{
    using GraphQL.AspNet.Attributes;
    using GraphQL.AspNet.Controllers;
    using GraphQL.AspNet.Interfaces.Execution.Variables;
    using Microsoft.AspNetCore.Mvc;

    public class InvoiceController : GraphController
    {

        [QueryRoot]
        public Invoice GetInvoice(string invoiceId)
        {
            // grab the different filter params supplied for each aliased "Items" field requested
            var allInvoiceItemFilterParams = new Dictionary<string, decimal>();
            foreach(var childField in this.Request.InvocationContext.ChildContexts)
            {
                if (string.Compare(childField.Field.Name, nameof(Invoice.Items), true) == 0)
                {
                    var alias = childField.FieldDocumentPart.Alias;
                    var argumentValue = Convert.ToDecimal(childField.Arguments[0].Value.Resolve(null));

                    allInvoiceItemFilterParams.Add(alias, argumentValue);
                }
            }

            // -----------------------------------------------------------------------
            // Do something here with the collected set of filters to query and create
            // a fully populated invoice with items that match either of the filters
            // -----------------------------------------------------------------------


            // Lets assume this object represents the the built object
            // (with invoice items that match either filter)
            var invoice = new Invoice()
            {
                Id = invoiceId,
                InvoiceDate = DateTime.Now.Date,


                // allItems is an internal property, hidden from the schema
                AllItems = new List<InvoiceItem>() {
                    new InvoiceItem()
                    {
                        Label = "Item AA",
                        Value = 15,
                    },
                    new InvoiceItem()
                    {
                        Label = "Item BB",
                        Value = 20,
                    },
                    new InvoiceItem()
                    {
                        Label = "Item CC",
                        Value = 25,
                    },
                    new InvoiceItem()
                    {
                        Label = "Item DD",
                        Value = 30,
                    },
                    new InvoiceItem()
                    {
                        Label = "Item EE",
                        Value = 35,
                    },
                }
            };

            // Notice we don't do anything to try and split the data up
            // we let graphql do its thing and naturally call the "Items" method
            // twice (once with each filter) and let that take care of returning the necessary data.
            return invoice;
        }
    }
}