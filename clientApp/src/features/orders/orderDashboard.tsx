import{ useEffect } from 'react'
import { useStore } from '../../app/stores/store';
import { observer } from 'mobx-react-lite';
import { Button, Grid, GridColumn, GridRow, Header, HeaderContent, HeaderSubheader, Table, TableBody, TableCell, TableHeader, TableHeaderCell, TableRow, Image, Label, Segment, Item, Divider } from "semantic-ui-react";



export default observer(function orderDashboard() {
  const { orderStore,cartStore } = useStore();


  useEffect(() => {
    orderStore.getAllOrder(cartStore.user.id)


  }, [orderStore.getAllOrder])


  return (

   <div>
     
          {orderStore.orders.map(
                    (order) => (
                        <Table basic='very'   >
                        <TableHeader>
                          <TableRow>
                            <TableHeaderCell  > Order No {order.id}</TableHeaderCell>
                            <TableHeaderCell textAlign='center'>Price</TableHeaderCell>
                            <TableHeaderCell textAlign='center'>Quantity</TableHeaderCell>
                            <TableHeaderCell textAlign='center'>Total</TableHeaderCell>
                          </TableRow>
                        </TableHeader>
              
                        <TableBody>
                        { order.items.map(item => (
                            <TableRow>
                              <TableCell width={8}>
                                <Header as='h4' >
                                <Image src={item.product.imageUrl} rounded size='mini' />
                                <HeaderContent >
                                    {item.product.name}
                                    <HeaderSubheader> {item.product.description}</HeaderSubheader>
                                </HeaderContent>
                                </Header>
                             </TableCell>   
                             <TableCell textAlign='center'>
                                {item.product.unitPrice}
                             </TableCell>    
                             <TableCell textAlign='center'>
                                {item.quantity}
                             </TableCell>     
                             <TableCell textAlign='center'>
                                {item.quantity*item.product.unitPrice}
                             </TableCell>                                            
                            </TableRow>                        
                            
                              ))}
                         
                        </TableBody>
                </Table>
                )
            
            )}
             
      

        </div>)

})
