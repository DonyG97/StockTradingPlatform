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
- Due to lack of domain knowledge and a basic understanding of how shares work I have assumed that each company has a total number of shares (of course it can choose whether to create more) and orders can only be processed if there are shares available

## <a name="init"></a> Initial thoughts
After first reading the requirements document the simplest solution, given the time frame, is to make a monolith RESTful API. Some alternatives were considered but this was deemed to be the simplest, please read the future considerations section for thoughts on alternate solutions.

There will be 3 projects:
- The REST API (dotnet core)
- The core logic - which is the model, data access and the business logic.
- The test project

The business/core logic could be split into two/three projects. If splitting into two projects it would be the model and data access in one project and the business logic in another:
- Model + data access
- Business logic
This would make sense should the solution as it keeps things cleaner

If splitting into three solutions then it would be the following:
-  Model
-  Data access
-  Business logic
This way different database technologies could be used for different models, for example, a time-series database for time-series data.


My domain knowledge around this area is lacking so there are some things that will need re-reading and thinking about. I doubt this is complex stuff but it's a new domain to me.

### Potential questions
When a company issues shares does this create an order? Assuming so as it would provide traceability
What is the expected response if you order shares but none are available?

## Source control
Git was chosen as the source control as it's the one I feel most comfortable with and I feel it also provides the best functionality.

Typically I would follow the [Gitflow workflow](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow) however as this is a small project and there are no work items to create feature branches against I'm just keeping it simple.

## Development approach

I have tried to use Test-Driven-Development (TDD) for the development of the application to try and ensure the requirements have been met. I do find that this is sometimes difficult when creating new applications as the infrastructure is not there yet and the design can change quite quickly. In this case I stubbed the tests cases out and had them all fail, I created basic implementations of the methods require so I could properly write the tests.

No specific naming convention has been used, typically I would use the Gherkin statement format (Given-When-Then) but for simpler tests I find this can be overkill.


## Outputs
### Documentation
I have generated the API spec from the code. It can be found in [json format](https://github.com/DonyG97/StockTradingPlatform/blob/master/SwaggerSpec.json) or in [yaml format](https://github.com/DonyG97/StockTradingPlatform/blob/master/SwaggerSpec.yaml).

When the Web API is ran it will load the swagger UI by default so the user can 

### REST API

When ran the REST API will load up for demo data that will allow the endpoints to be used.

### Test project

A test project has been produced with tests covering the core logic that is found in the two service classes. Sadly I haven't had enough time to run test coverage, so I'm unsure what I'm missing.

## Issues Encountered
- Domain knowledge was a big issue as I don't have much knowledge of how stocks work which is why I had to put an amount onto the Company object
- I feel 1/1.5 hours for this is not enough. It may be that I have gone slow or have exceeded the requirements but i've definitely spent more than the allowed time frame. I wouldn't have felt comfortable submitting what I had produced in the specified time frame which is why I spent more time. However, once I exceeded the time frame I tried to only work on the essentials to meet the spec, due to this somethings have been missed, such as manually testing all endpoints.

## Future Considerations
If the project needed to consider scalability then switching to a microservice based approach would be a better solution as it would provide better performance for large scale applications. With a microservice approach each service would handle a specific concept within the application and have it's own database. 
 
This could be taken further by splitting data in and data out into separate data stores so they are independent of each other. This comes with complexities as the two data stores would need to be kept in sync.

List of items:
- Complete all todo comments
- Integration tests for the Web API. Sadly, I did not have the chance to test all the endpoints out
- Use interfaces on the services that the Web API consume, this way they could easily be mocked for testing purposes
- Add more xml comments
- Create custom exceptions and messages for certain issues
- As talked about in the [initial thoughts section](#init), I would look to split the core project into 3 seperate projects. 
- Could look into a way of doing this event-driven. So an order would come and trigger other events such as the processing for the existing orders. However, this is not something I've done before in regards to a Web API so it would need some research
- Make use of development appsettings and have the DemoDataService only run if in development mode


