### Mediatr and cqrs
#### Pros:
1. Very easy to add additional dependencies without modifying the whole chain
2. Commands and queries in general encourage a better approach to db-related tasks 
3. Commands and queries offer a more uniform approach, which covers database as well as 3p APIs, files, etc
#### Cons
1. It's not entirely clear what commands are 'entry points' and what are simply dependencies
2. Dependencies are not obvious from the signature, bearing resemblance to Service Locator 
3. Hard to debug and navigate the code 
4. Hard to reason about if commands create other commands making a tree-like dependency graph 
5. Hard to Unit Test without looking at the source code