import { Button, Container, Grid, Label } from 'semantic-ui-react'
import { useStore } from '../../../app/stores/store';
import { useEffect, useState } from 'react';
import { observer } from 'mobx-react-lite';
import LoadingComponent from '../../../app/layout/LoadingComponent';
import ProductList from './productList';
import Cart from './Cart';
import { PagingParams } from '../../../app/models/pagination';





export default observer(function productDashboard() {

  const { productStore } = useStore();
  const { loadProducts, loadingInitial, SetPagingParams, pagination } = productStore;

  const [loadingNext, setLoadingNext] = useState(false)

  function handleGetNext() {
    setLoadingNext(true);
    SetPagingParams(new PagingParams(pagination!.currentPage + 1))
    loadProducts().then(() => setLoadingNext(false))
  }

  function handleGetPrev() {
    setLoadingNext(true);
    SetPagingParams(new PagingParams(pagination!.currentPage -1))
    loadProducts().then(() => setLoadingNext(false))
  }

  useEffect(() => {
    loadProducts();
  }, [loadProducts])


  if (loadingInitial) return <LoadingComponent content='Loading app' />

  return (
    <Container style={{ marginTop: '7em' }}>
      <Grid>
        <Grid.Column width='12'>
          <ProductList />
         
          <Label  size="medium">
          <Button
          size='mini'
            floated='right'
            icon='long arrow alternate right'
            
              color= 'grey'
            onClick={handleGetNext}
            loading={loadingNext}
            disabled={pagination?.totalPages===pagination?.currentPage}>

          </Button>
             Page {pagination?.currentPage} of {pagination?.totalPages}
           
          <Button
           size='mini'
            floated='left'
            icon='long arrow alternate left'
            
            color= 'grey'        
            onClick={handleGetPrev}
            loading={loadingNext}
            disabled={(pagination?.currentPage??0)==1}>
              
              

          </Button>
        </Label>
        
        </Grid.Column>

        <Grid.Column width='4'>
          <Cart />
        </Grid.Column>

      </Grid>
    </Container>

  )
})
