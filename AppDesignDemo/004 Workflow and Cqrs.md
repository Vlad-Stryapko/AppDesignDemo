### Workflows and cqrs
#### Pros:
1. Commands and queries in general encourage a better approach to db-related tasks 
2. Commands and queries offer a more uniform approach, which covers database as well as 3p APIs, files, etc
3. All the dependencies are explicit, thus making reasoning about the code much easier
4. Easy to setup UTs 
5. Clear separation of main flows and their dependencies
6. Easy to debug and navigate the code
#### Cons
1. Might lead to code duplication
2. Requires a bit more typing (unless some generators are used)
