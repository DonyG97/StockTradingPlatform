# StockTradingPlatform
Coding challenge for the Blackfinch interview

## Constraints
- Maximum 1.5 hours to be spent on the solutions
- A dotnetcore project is to be used
- A testing project needs to be used
- An API spec doc needs to be produced

## Assumptions
- Any test framework can be used. I have chosen to use NUnit as it's the one I'm most familiar with. The alternative would be XUnit
- There are no security or user system requirements, so any requests made are anonymous
- No data validation is needed 

## Initial thoughts
After first reading the requirements document the simplest solution, given the time frame, is to make a monolith RESTful API. Some alternatives were considerd but this was deemed to be the simplest, please read the future considerations section for thoughts on alternate solutions.

There will be 3 projects:
- The REST API (dotnet core)
- The core logic - which is the model, data acces and the business logic.
- The test project

The business/core logic could be split into two/three projects. If splitting into two projects it would be the model and data access in one project and the business logic in another:
- Model + data access
- Business logic
This would make sense should the solution as it keeps things cleaner

If splitting into three solutions then it would be the following:
-  Model
-  Data access
-  Business logic
This way different database technologies could be used for different models, for example a time series database for time series data.


My domain knowledge around this area is lacking so there are some things that will need re-reading and thinking about. I doubt this is complex stuff but it's a new domain to me.

### Potential questions
When a company issues shares does this create an order? Assuming so as it would provide traceability
What is the expected response if you order shares but none are available?

## Source control
Git was chosen as the source control as it's the one I feel most comfortable with and I feel it also provides the best functionality.

Typically I would follow the [Gitflow workflow](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow) however as this is a small project and there are no work items to create feature branches against I'm just keeping it simple.