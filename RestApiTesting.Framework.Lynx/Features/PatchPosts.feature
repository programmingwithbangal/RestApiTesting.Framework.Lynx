Feature: PatchPosts
As a non-authenticated user,
I want the ability to patch a post.

  Background: 
    Given I have a client "nonAuthenticatedHttpClient1"
  
  @AcceptanceCriteria
  Scenario: A non-authenticated user successfully patchs a post
    Given I have a model "patchPostsModel1" with the following values:
      | Field | Value            | 
      | body  | str patched body | 
     When I send a "Patch" request to "str /posts/1" with model "key patchPostsModel1" using client "key nonAuthenticatedHttpClient1" and get the response "patchPostsResponse1"
      And I get the content "patchPostsResponse1Body" of the response "key patchPostsResponse1"
     Then the response "patchPostsResponse1" should have the status code "OK"
      And the model "patchPostsResponse1Body" should match the following values:
      | Field  | Value                                                                          | 
      | userId | int 1                                                                          | 
      | id     | int 1                                                                          | 
      | title  | str sunt aut facere repellat provident occaecati excepturi optio reprehenderit | 
      | body   | ref body of patchPostsModel1                                                   | 
  
  @NegativePath
  Scenario: A non-authenticated user attempts to patch a post with nonexistent id
    Given I have a model "patchPostsModel1" with the following values:
      | Field | Value            | 
      | body  | str patched body | 
     When I send a "Patch" request to "str /posts/101" with model "key patchPostsModel1" using client "key nonAuthenticatedHttpClient1" and get the response "patchPostsResponse1"
      And I get the content "patchPostsResponse1Body" of the response "key patchPostsResponse1"
     Then the response "patchPostsResponse1" should have the status code "OK"
      And the model "patchPostsResponse1Body" should match the following values:
      | Field | Value                        | 
      | body  | ref body of patchPostsModel1 | 