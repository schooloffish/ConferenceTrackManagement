import './main.css';
import React from 'react';
import ReactDOM from 'react-dom';
import App from './app';
import { TodoStore } from './todoStore';
import { Provider } from 'mobx-react'
import { BrowserRouter } from 'react-router-dom';

const app = document.getElementById('app');
const store = { todoStore: new TodoStore() };
ReactDOM.render(
    <Provider {...store}>
        <BrowserRouter>
            <App />
        </BrowserRouter>
    </Provider>
    , app);