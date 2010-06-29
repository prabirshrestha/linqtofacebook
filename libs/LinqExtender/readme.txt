LinqExtender
=============
A toolkit to create custom LINQ providers

Minimum framework requirement 
==============================
- .NET 3.5

Getting Started
=================

1. Add reference LINQExtender.dll and System.Core namespace

2. Define a query object that will inherit IQueryObject interface.

Ex.

public class Photo
{
...
...
}

3. Define Query provider that inherits Query<T>  and override the following methods.


public class FlickrPhotoQuery : Query<Photo>
{
	public FlickrPhotoQuery()
	{
		Extender
			.Settings
				.For<Photo>()
					.Begin
						.Property(x => x.Id).MarkAsUnique()
					.End
		.InstantiateIn(this);
	}

        protected override bool AddItem(IBucket bucket)
        {
            // TOOD : Implenment data access logic, 
            Build Add query.
            if you change something, then it will be reflected back, like after this scope the Id value will contain 222;
            
	    FluentBucket.As(bucket).For.Item("id").Value = 222;
             
            // true means a success and the collection will be updated with latest modificaiton
            //false means fail, and will raise an OnError event stating the fact.
            return true/false;
        }

        protected override bool RemoveItem(IBucket bucket)
        {
            // TODO : Implement data access logic
            Build Remove query
            return true/false;
        }
        protected override void SelectItem(IBucket bucket, Linq.Extended.Interface.IModify<Photo> items)
        {
            // TODO :  populate collection on basis of bucket object.
           
            // do a add range.
            items.AddRange (list);
        }
        protected override bool UpdateItem(IBucket bucket)
        {
            // TODO : Implement data access logic
            Build Remove query
            return true/false;
        }
        
        //// method is invoked when uniqueIdentifier is used in where clause
        //// and is called when overriden.
        protected T GetItem()
        {
            populate and return the Identity Object.
        }

}


Descrition of Bucket object [ Fluent interface]

FluentBucket fluentBucket = FluentBucket.As(bucket);

fluentBucket.Entity.Name
fluentBucket.Entity.UniqueAttribute
fluentBucket.Entity.ItemsToFetch;
fluentBucket.Entity.ItemsToSkip; - default  0


Iterators

fluentBucket.For.EachItem.Match(delegate(BucketItem item)
{

 return <condtion(s) to match , ex item.Unique == true>

})
.Process(delegate(BucketItem item)
{
	/// do your work.   
});;

Note: "Match" is optional


To work on single item you can do the follwoing (Ex. getting the value of ID property).

fluentBucket.For.Item("ID").value;
 

To process OrderBy try the following

fluentBucket.Entity.OrderBy.IfUsed.Process(delegate(string field, bool ascending)
{
  /// do your work.
});
                                                          

That's it
Enjoy.
