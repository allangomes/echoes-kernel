# Echoes Kernel 1.0.0

Sample Application using [Auxo.Net](https://github.com/allangomessl/auxo.net) Framework

### Tags
`Asp.Net Core` `Entity Framework Core` `PostgresSQL` `Dependency Injection` `NUnit` `TestHost` `Json.Net`

### Documentation
- [Documentation](https://github.com/allangomessl/echoes-kernel/wiki)

### Dependencies
- [Auxo.Net (Allan Gomes)](https://github.com/allangomessl/auxo.net)
- [NUnit (NUnit)](https://github.com/nunit/nunit)

### Roadmap
###### 1.0.1
- Core
  - [ ] User
- API
  - [ ] Authentication with JWT and Redis
  - [ ] Localization Used Based with Json Resource
  - [ ] Refactoring Errors Validation Result


### Releases

###### 1.0.0
- Core
  - [x] Models
  - [x] Validations
  - [x] Unit Test 
- Data
  - [x] Database Mapping
- Infra
  - [x] Dependencies Resolution
- API
  - [x] Configure file `settings.{env}.json` suported
  - [x] Result Http Rest Based
  - [x] Generic Crud Controller `CrudController`
  - [x] Ignore `null` in Json Result
  - [x] Ignore `Case` in Json
  - [x] Result `LowerCamelCase` in Json
  - [x] Unit Test
