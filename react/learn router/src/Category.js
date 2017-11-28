import React from 'react';
import { Link, Route } from 'react-router-dom';
const Category = (props) => {
    return (<div>
        <h1>category name is {props.match.params.name}</h1>
    </div>
    )
}
export default Category;