import React from 'react';
import { Route, Switch, Link } from 'react-router-dom';

import Test from './test';
import Test2 from './test2';
import TodoList from './todoList';

export default class App extends React.Component {
    render() {
        return <div>
            <nav>
                <ul>
                    <li><Link to='/'>main</Link></li>
                    <li><Link to='/test'>Go Test</Link></li>
                    <li><Link to='/todo'>todo</Link></li>
                </ul>
            </nav>
            <button> ok </button>
            <div>
                holy shit!!
        </div>
            <Switch>
                <Route exact path='/' component={Test2} />
                <Route path='/test' component={Test} />
                <Route path='/todo' component={TodoList} />
            </Switch>
        </div>

    }
}