Stock Trading Platform
An Restful API implementation of a simple stock trading platform.

Requirements
Create an API specification and build an API in dotnet core for a stock trading platform with the following requirements, note that no database setup is required - use a singleton for any storage needs spanning multiple requests.

Get companies - list of predefined companies with the following symbols - AMZN, TSLA and BLKFNCH.
Companies can issue shares, a quantity of shares are issued at a set price.
Create orders
An order consists of a symbol, min order price, max order price, quantity, and type (buy or sell).
Get outstanding orders - an order has a status of processing or complete.
Get status of a specific order
If an order is created that can't be satisfied, it remains in a backlog queue until it is able to be addressed by an incoming order.
Set initial shares for each company as 100,000 @ £40 for AMZN, 10,000 @ £420 for TSLA and 600 @ £60 for BLKFNCH. Set starting orders for each company as

[
  { "symbol":"AMZN", "min":40, "max":40, "quantity":100, "type":"buy" },
  { "symbol":"TSLA", "min":200, "max":1000, "quantity":2000, "type":"buy" },
  { "symbol":"BLKFNCH", "min":60, "max":60, "quantity":30, "type":"buy" }
]
Outcomes
API specification - Code generated (eg. swagger) or OpenAPI yaml document
dotnet core project
testing (minimal tests, no need for complete test coverage)
Submission
Send through a public link to your GIT repository prior to interview.