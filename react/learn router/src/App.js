import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import { Link, Route, Switch } from 'react-router-dom';
import Category from './Category';

const Home = () => (
  <div>
    <h2>Home</h2>
  </div>
)

const Products = () => (
  <div>
    <h2>Products</h2>
  </div>
)

class App extends Component {
  render() {
    return (
      <div>
        <nav>
          <ul>
            <li><Link to="/">Homes</Link> </li>
            <li><Link to="/category/shoes">Category:shoes</Link> </li>
            <li><Link to="/category/clothes">Category:clothes</Link> </li>
            <li><Link to="/category/tools">Category:tools</Link> </li>
            <li><Link to="/products">Products</Link> </li>
          </ul>
        </nav>

        <Switch>
          <Route exact={true} path="/" component={Home} />
          <Route path="/category/:name" component={Category} />
          <Route path="/products" component={Products} />
        </Switch>
      </div>
    );
  }
}

export default App;
