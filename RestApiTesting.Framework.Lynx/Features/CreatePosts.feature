Feature: CreatePosts
As a non-authenticated user,
I want the ability to create a post.

  Background: 
    Given I have a client "nonAuthenticatedHttpClient1"
  
  @AcceptanceCriteria
  Scenario: A non-authenticated user successfully creates a post
    Given I have a "str title" named "title1"
      And I have a "str body" named "body1"
      And I have a model "createPostsModel1" with the following values:
      | Field  | Value      | 
      | userId | int 1      | 
      | id     | int 101    | 
      | title  | key title1 | 
      | body   | key body1  | 
     When I send a "Post" request to "str /posts" with model "key createPostsModel1" using client "key nonAuthenticatedHttpClient1" and get the response "createPostsResponse1"
      And I get the content "createPostsResponse1Body" of the response "key createPostsResponse1"
     Then the response "createPostsResponse1" should have the status code "Created"
      And the model "key createPostsResponse1Body" should match the following values:
      | Field  | Value                           | 
      | userId | ref userId of createPostsModel1 | 
      | id     | ref id of createPostsModel1     | 
      | title  | ref title of createPostsModel1  | 
      | body   | ref body of createPostsModel1   |
