import * as React from "react";
import * as ReactDom from "react-router-dom";
import Category from "./Category";
import Sentence from "./Sentence";
import WordList from "./WordList";
import Phrase from "./Phrase";

const Home: any = () => (
  <div>
    <h2>Home</h2>
  </div>
);

const Products: any = () => (
  <div>
    <h2>Products</h2>
  </div>
);

const App: any = () => (
  <div>
    <nav>
      <ul>
        <li><ReactDom.Link to="/">Homes</ReactDom.Link> </li>
        <li><ReactDom.Link to="/category/shoes">Category:shoes</ReactDom.Link> </li>
        <li><ReactDom.Link to="/category/clothes">Category:clothes</ReactDom.Link> </li>
        <li><ReactDom.Link to="/wordList">WordList</ReactDom.Link> </li>
        <li><ReactDom.Link to="/sentence">Sentence</ReactDom.Link> </li>
        <li><ReactDom.Link to="/phrase">Phrase</ReactDom.Link> </li>
      </ul>
    </nav>

    <ReactDom.Switch>
      <ReactDom.Route exact={true} path="/" component={Home} />
      <ReactDom.Route path="/category/:name" component={Category} />
      <ReactDom.Route path="/products" component={Products} />
      <ReactDom.Route path="/sentence" component={Sentence} />
      <ReactDom.Route path="/wordList" component={WordList} />
      <ReactDom.Route path="/phrase" component={Phrase} />
    </ReactDom.Switch>
  </div>
);

export default App;
