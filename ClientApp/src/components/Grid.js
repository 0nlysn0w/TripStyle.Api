import React, { Component } from 'react'
import { Grid, Image, Card, CardContent, Icon, Divider } from 'semantic-ui-react';
import { NavLink } from 'react-router-dom';

export default class GridExampleRelaxed extends Component {
  constructor(props) {
    super(props);
    this.state = {
      items: [],
      isLoaded: false
    }
  }
  componentDidMount() {
    fetch('https://jsonplaceholder.typicode.com/users')
      .then(res => res.json())
      .then(json => {
        this.setState({
          isLoaded: true,
          items: json
        })
      });
  }
  render() {
    var { isLoaded, items } = this.state;
    if (!isLoaded) {
      return <div>Loading...</div>;
    }
    if (items && (items.length = 5)) {
      return (
        <Grid>
          <Grid.Row columns={5} centered relaxed>
            {items.map(item => (
              <Grid.Column>
                <NavLink to='./product'>
                  <Card href='#card-example-link-card' color='teal'>
                    <Image src='https://react.semantic-ui.com/images/wireframe/image.png' />
                    <CardContent>
                      <Card.Header><Icon name='euro sign' />{item.id}</Card.Header>
                      <Card.Meta>{item.name}</Card.Meta>
                      <Card.Description>{item.email}</Card.Description>
                      {/* <Menu.Item className='header'>{item.email}</Menu.Item> */}
                    </CardContent>
                  </Card>
                  <Divider hidden />
                </NavLink>
              </Grid.Column>
            ))}
          </Grid.Row>
        </Grid>
      )
    } else {
      return <div>No items found</div>
    }
  }
}