### Objective 3 - Review the existing code


Apologies for the time taken to get to this just had Black Friday and now going into End of Season Sale period

Also Github and EF DB migrations are not my usual working environment, mostly a bit detached from actual coding of late apart for POCs etc

I like the Controller Builder Command View Models separation

I have some concerns with the use of Entity framework for a high availability high performance website, often the SQL that is created is often suboptimal. 

A missing Models for the Manage Views for example the Password reset

Some files seem to have more than one class within them.

Lacking in tests - Code Coverage is very low.

All seems to be in the one monolith I would like to see the functions split into their own services, especially something like Search.

The separation of Seller and Buyer might need some reworking as Sellers are usually Buyers aswell.

Needs some more error handling, removing the defaul error response and headers to not give away any infomation on server architecture etc.

CDN for imagery and other site furniture. Cahcing for some of the more heavily looked at pages.

Look at creating some tests or third party tools for performance/ stress testing.

Would be good to see the bigger picture to create an As-Is existing architecture to then propose the To-Be future architecture to make sure nothing is being overlooked by focusing on individual tasks.

Thank you
Steve