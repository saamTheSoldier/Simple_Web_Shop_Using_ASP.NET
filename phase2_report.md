## phase2 report
3. [ ] **Phase 2: Make the web app more general**
    - [ ] Design the DB and draw ER for that
        - To do this let me break down our features. We want to have Category creation that
          may be nested and have hierarchical order. There will be Product entity. Also, we should be
          able to create fields assigning to a category and has value for category or product.
        - For the first solution showed up in my mind I think of a db design like this ER diagram:
          ```mermaid
          erDiagram
              Categories {
                  int id PK
                  varchar name
                  int parent_id FK
              }
          
              Fields {
                  int id PK
                  varchar name
                  varchar data_type
              }
          
              CategoryFields {
                  int id PK
                  int category_id FK
                  int field_id FK
              }
          
              Products {
                  int id PK
                  varchar name
                  int category_id FK
              }
          
              FieldValues {
                  int id PK
                  int field_id FK
                  int entity_id
                  enum entity_type
                  varchar value
              }
          
              Categories ||--o{ Categories : parent_id
              Categories ||--o{ CategoryFields : category_id
              Fields ||--o{ CategoryFields : field_id
              Categories ||--o{ Products : category_id
              Fields ||--o{ FieldValues : field_id
          
          ```
        - Ok, is this good enough? What are its probs ans cons? 
          - First in FieldValue table, in this way of design, we may loss some ORM features as the entity could be
          whether Category or Product. One solution could be to redesign it so the table having two column 
          category_id and product_id at the same time instead of entity_type and entity_id. Note that then we should
          add some constraint to handle probable bad interference of two columns.
        - Could we make this design better?
          - I had a converstation in this subject with IAIS teamlead. As he said based on his exprience in such projects
          when we have categories that treated much like product it will be good to forget about Category to be an
          entity and then treat it like a product, so in product table, we can have them but adding a column "is_category"
          for ease of knowing them. We discussed about it and I was convinced this is a good idea in our case.