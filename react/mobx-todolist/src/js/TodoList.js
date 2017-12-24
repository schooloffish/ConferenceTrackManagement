import React from 'react';
import { observer } from 'mobx-react';

@observer(['todoStore'])
export default class TodoList extends React.Component {
    createNew(e) {
        if (e.which === 13) {
            this.props.todoStore.createTodo(e.target.value);
            e.target.value = '';
        }
    }

    filter(e) {
        this.props.todoStore.filter = e.target.value;
    }

    toggleComplete(todo) {
        todo.complete = !todo.complete;
    }

    render() {
        const { clearComplete, filter, filteredTodos, todos } = this.props.todoStore;

        const todoLis = filteredTodos.map(todo => (
            <li key={todo.id}>
                <input type="checkbox" onChange={this.toggleComplete.bind(this, todo)} checked={todo.complete} />
                <span>{todo.value}</span>
            </li>
        ));
        return <div>
            <h1>todos</h1>
            <input className="new" onKeyPress={this.createNew.bind(this)} />
            <input className="filter" value={filter} onChange={this.filter.bind(this)} />
            <ul>{todoLis}</ul>
            <a href="#" onClick={clearComplete}>Clear Complete</a>
        </div>

    }
}