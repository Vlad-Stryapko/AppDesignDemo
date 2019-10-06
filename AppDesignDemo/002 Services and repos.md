### Services and repos
#### Pros:
1. Easy to understand and pick-up
2. Offer some level of SoC via layers 
3. UoW allows Service layer to control the transaction 
#### Cons
1. Layers themselves become large and complex
2. Despite the initial goal, don't offer that much of a database abstraction 
3. Reposiories are used mainly for DB, even though they make sense for 3p APIs, files, etc
4. Control over the transaction often becomes useless as soon as first distributed operation appears