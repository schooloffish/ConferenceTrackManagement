import * as React from "react";
import * as ReactDOM from "react-dom";

const WordList: any = (props: any) => {
    const allPhrases: any = [{
        phrase: "hello",
        phonetic: "haha",
        meaning: "test",
        update_time: new Date()
    }, {
        phrase: "thanks",
        phonetic: "xixi",
        meaning: "test again",
        update_time: new Date()
    }];

    return <table>
        <tbody>
            <tr>
                <th>Word</th>
                <th>phonetic</th>
                <th>Meaning</th>
                <th>Update Date</th>
            </tr>
            {allPhrases.map((p: any, index: number) => {
                return <tr key={index}>
                    <td> {p.phrase}</td>
                    <td>{p.phonetic}</td>
                    <td>{p.meaning}</td>
                    <td>{p.update_time.toString()}</td>
                </tr>;
            })}
        </tbody>
    </table >;
};

export default WordList;