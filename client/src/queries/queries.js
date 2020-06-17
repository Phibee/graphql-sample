import gql from "graphql-tag";

const getDepartmentsQuery = gql`
     {
          departments {
               id
               title
               description
          }
     }
`;

const createDepartmentMutation = gql`
     mutation createDepartment($title: String, $description: String) {
          createDepartment(
               department: { title: $title, description: $description }
          ) {
               id
               title
               description
          }
     }
`;

const deleteDepartmentMutation = gql`
     mutation deleteDepartment($id: Long!) {
          deleteDepartment(department: { id: $id }) {
               id
          }
     }
`;

export {
     createDepartmentMutation,
     getDepartmentsQuery,
     deleteDepartmentMutation,
};
