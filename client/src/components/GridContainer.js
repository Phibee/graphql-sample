import React, { useEffect } from "react";
import {
     Grid,
     GridColumn,
     GridToolbar,
     GridCell,
} from "@progress/kendo-react-grid";
import { graphql, useQuery } from "react-apollo";
import {
     getDepartmentsQuery,
     deleteDepartmentMutation,
} from "../queries/queries";
import { flowRight as compose } from "lodash";
// import MyCommandCell from './MyCommandCell'

const GridContainer = ({
     changeRowSelection,
     addItem,
     inEdit,
     getDepartments,
     deleteDepartmentMutation,
}) => {
     const remove = (dataItem) => {
          deleteDepartmentMutation({
               variables: {
                    id: dataItem.id,
               },
               refetchQueries: [{ query: getDepartmentsQuery }],
          });
          console.log("removed. " + dataItem.id);
     };

     const UnitsInStockCell = (props) => {
          return (
               <td colSpan={props.colSpan} style={props.style}>
                    <button
                         className="k-button k-grid-remove-command"
                         onClick={(e) =>
                              window.confirm(
                                   "Confirm deleting: " + props.dataItem.title,
                              ) && remove(props.dataItem)
                         }
                    >
                         Remove
                    </button>
               </td>
          );
     };

     return (
          <div>
               <Grid
                    data={
                         getDepartments.loading === true
                              ? []
                              : getDepartments.departments
                    }
               >
                    <GridToolbar></GridToolbar>
                    <GridColumn field="title" title="ID" width="300" />
                    <GridColumn field="description" width="300" />
                    <GridColumn title="Command" cell={UnitsInStockCell} />
               </Grid>
          </div>
     );
};

// export default GridContainer;
export default compose(
     graphql(getDepartmentsQuery, { name: "getDepartments" }),
     graphql(deleteDepartmentMutation, { name: "deleteDepartmentMutation" }),
)(GridContainer);
