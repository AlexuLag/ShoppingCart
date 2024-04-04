import { Fragment } from "react/jsx-runtime";
import { useStore } from "../../../app/stores/store";
import { Button,  Table, TableBody, TableCell, TableHeader, TableHeaderCell, TableRow } from "semantic-ui-react";
import { observer } from "mobx-react-lite";


export default observer(function CartDashboard() {
  const { cartStore } = useStore();

  const { productsInCart } = cartStore;

  return (




      <Table  singleLine>
        <TableHeader>
          <TableRow>
            <TableHeaderCell>Product</TableHeaderCell>
            <TableHeaderCell>Price</TableHeaderCell>
            <TableHeaderCell>Quantity</TableHeaderCell>
            <TableHeaderCell>Total</TableHeaderCell>
            <TableHeaderCell>option</TableHeaderCell>
          </TableRow>
        </TableHeader>

        <TableBody>
          {productsInCart.map((p) => (
            <TableRow>
              <TableCell >
                {p.product.name}
              </TableCell>
              <TableCell>
                {p.product.unitPrice}
              </TableCell>
              <TableCell>
                {p.quantity}
              </TableCell>
              <TableCell>
                {p.quantity * p.product.unitPrice}
              </TableCell>
              <TableCell>
                <Button circular icon='trash'/>
              </TableCell>
            </TableRow>
          )
          )}
        </TableBody>
      </Table>
  )

})