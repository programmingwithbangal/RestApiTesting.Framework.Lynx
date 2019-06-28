Feature: UpdatePosts
As a non-authenticated user,
I want the ability to update a post.

  Background: 
    Given I have a client "nonAuthenticatedHttpClient1"
  
  @AcceptanceCriteria
  Scenario: A non-authenticated user successfully updates a post
    Given I have a model "updatePostsModel1" with the following values:
      | Field  | Value             | 
      | userId | int 1             | 
      | title  | str updated title | 
      | body   | str updated body  | 
     When I send a "Put" request to "str /posts/1" with model "key updatePostsModel1" using client "key nonAuthenticatedHttpClient1" and get the response "updatePostsResponse1"
      And I get the content "updatePostsResponse1Body" of the response "key updatePostsResponse1"
     Then the response "updatePostsResponse1" should have the status code "OK"
      And the model "updatePostsResponse1Body" should match the following values:
      | Field  | Value                           | 
      | userId | ref userId of updatePostsModel1 | 
      | id     | int 1                           | 
      | title  | ref title of updatePostsModel1  | 
      | body   | ref body of updatePostsModel1   | 
  
  @NegativePath
  Scenario: A non-authenticated user attempts to update a post with nonexistent id
    Given I have a model "updatePostsModel1" with the following values:
      | Field  | Value             | 
      | userId | int 1             | 
      | title  | str updated title | 
      | body   | str updated body  | 
     When I send a "Put" request to "str /posts/101" with model "key updatePostsModel1" using client "key nonAuthenticatedHttpClient1" and get the response "updatePostsResponse1"
     Then the response "updatePostsResponse1" should have the status code "InternalServerError"