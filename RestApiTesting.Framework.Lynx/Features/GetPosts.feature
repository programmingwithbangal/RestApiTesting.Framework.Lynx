Feature: GetPosts
As a non-authenticated user,
I want the ability to get a post.

  Background: 
    Given I have a client "nonAuthenticatedHttpClient1"
  
  @AcceptanceCriteria
  Scenario: A non-authenticated user successfully gets a post
     When I send a "Get" request to "str /posts/1" using client "nonAuthenticatedHttpClient1" and get the response "getPostsResponse1"
      And I get the content "getPostsResponse1Body" of the response "key getPostsResponse1"
     Then the response "getPostsResponse1" should have the status code "OK"
      And the model "getPostsResponse1Body" should match the following values:
      | Field  | Value                                                                                                                                                                 | 
      | userId | int 1                                                                                                                                                                 | 
      | id     | int 1                                                                                                                                                                 | 
      | title  | str sunt aut facere repellat provident occaecati excepturi optio reprehenderit                                                                                        | 
      | body   | str quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto | 
  
  @NegativePath
  Scenario: A non-authenticated user attempts to get a post with nonexistent id
     When I send a "Get" request to "str /posts/101" using client "nonAuthenticatedHttpClient1" and get the response "getPostsResponse1"
      And I get the content "getPostsResponse1Body" of the response "key getPostsResponse1"
     Then the response "getPostsResponse1" should have the status code "NotFound"