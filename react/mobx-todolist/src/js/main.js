import '../css/main.css';
import React from 'react';
import ReactDOM from 'react-dom';
import TodoStore from './TodoStore';
import TodoList from './TodoList';
import { Provider } from 'mobx-react';

const app = document.getElementById('app');
const stores = { todoStore: TodoStore };

ReactDOM.render(
    <Provider {...stores}>
        <TodoList/>
    </Provider>
    , app);