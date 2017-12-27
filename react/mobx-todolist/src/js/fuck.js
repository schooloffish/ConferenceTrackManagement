import ReactDOM from 'react-dom';
import React from 'react';
import { BrowserRouter, HashRouter, Route, Link } from 'react-router-dom';

const App = () => (
    <BrowserRouter>
        <div>
            <AddressBar />

            <ul>
                <li><Link to="/">Home</Link></li>
                <li><Link to="/about">About</Link></li>
                <li><Link to="/topics">Topics</Link></li>
            </ul>

            <hr />

            <Route exact path="/" component={Home} />
            <Route path="/about" component={About} />
            <Route path="/topics" component={Topics} />
        </div>
    </BrowserRouter>
)

const Home = () => (
    <div>
        <h2>Home</h2>
    </div>
)

const About = () => (
    <div>
        <h2>About</h2>
    </div>
)

const Topics = ({ match }) => (
    <div>
        <h2>Topics</h2>
        <ul>
            <li><Link to={`${match.url}/rendering`}>Rendering with React</Link></li>
            <li><Link to={`${match.url}/components`}>Components</Link></li>
            <li><Link to={`${match.url}/props-v-state`}>Props v. State</Link></li>
        </ul>

        <Route path={`${match.url}/:topicId`} component={Topic} />
        <Route exact path={match.url} render={() => (
            <h3>Please select a topic.</h3>
        )} />
    </div>
)

const Topic = ({ match }) => (
    <div>
        <h3>{match.params.topicId}</h3>
    </div>
)

const AddressBar = () => (
    <Route render={({ location: { pathname }, goBack, goForward }) => (
        <div className="address-bar">
            <div>
                <button
                    className="ab-button"
                    onClick={goBack}
                >◀︎</button>
            </div>
            <div>
                <button
                    className="ab-button"
                    onClick={goForward}
                >▶</button>
            </div>
            <div className="url">URL: {pathname}</div>
        </div>

    )} />
)

ReactDOM.render(<App />, document.getElementById('app'))