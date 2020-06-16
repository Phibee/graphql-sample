import gql from 'graphql-tag';

const getDepartmentsQuery = gql `{
    departments{
      id
      title
      description
    }
}`;

const deleteDepartmentMutation = gql `
mutation deleteDepartment($id: Long!){
  deleteDepartment(department:{
    id: $id
  }) {
    id
  }
}`;

export { getDepartmentsQuery, deleteDepartmentMutation }; 