import React, { useEffect } from "react";
import { GridCell } from "@progress/kendo-react-grid";

const MyCommandCell = () => {
     return class extends GridCell {
          render() {
               return (
                    <button
                         className="k-button k-grid-remove-command"
                         // onClick={(e) => window.confirm('Confirm deleting: ' + this.props.dataItem.ProductName) && remove(this.props.dataItem)}
                    >
                         Remove
                    </button>
               );
          }
     };
};

export default MyCommandCell;
