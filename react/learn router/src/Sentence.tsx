import * as React from "react";
import * as ReactDOM from "react-dom";

export default class Sentense extends React.Component<{}, {}> {
    audio: HTMLAudioElement;
    vocabularies: string[];
    icon: string;

    constructor(props: any) {
        super(props);
        this.audio = new Audio();
        this.play = this.play.bind(this);
        this.vocabularies = ["test", "hello world"];
        this.icon = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAALEwAACxMBAJqcGAAAAq1JREFUSIntU01IVFEYPd99b8TBeW9SLHMRwVQQtCjKXUEYtSvaiWD51Mr+fC9rIIIglX4gomRmtE3+zJswSIrKaBNRVAsJa9EiougHKpLInHwzJY3z7tdinKeGCbX2LM937zn3nI8LzGMewebLazXLvrrwQH8gz+mHL5VMP6Ob9q2gFW+E0Vv4530xp/ghew/LbA2YaVxJ+b2B69unm/Eu3erZAgCOWljNEI6u06k/NWg24bJwoujnBJ8n4JETNa5oZvwakTzrRBuGppJ1h9yssoUUDKcidQP5ZNItiKaL/Q1oq8p4BkXWlTIV2e0gZgYcMHYyiXAqsvMVAGhmol+w+wSKcFhkrjvte0Y9I9NulSyHUh31dwBAP2hXQOEqJ1p31KuIkDnGkOXM+AGwcKLG1rx4DhIuyQQLekBZNayb8WX5yVjMaCVBG0ubr5cDgNNpPCXwSNDqWwcAas6AxplwNxUxBufaidNe+yZgXu4j4a4H8NYbML5lXGc1gOHJ5r8z3BUAns255NmQju14CSkWoeWB6uUjvGaSpVOB3XeSZLFX0b8gaCbWEOET2iqzeU4wVhJ8X7xAQl0uQKOAVxGnmalBs+xtJPmXIqg3GTU+zGYgiVdl3Yn7M0ghNjgLlpzzDEguVifosZfA7xMREHpAuO2Kghsu46Rm2Vuna5AoKNGteBMzfRzv3P3ZS2TZZwju8XyioNlVCRZK8mLdi9zj/wLNtI8Q4HdixmnNjPeTwg8VwQPJCw0fg/v7iqWarQdxiEncS0dqbwKT/yfjdqdi9dXew/5aNoBgk71ZEjcC8DHcxnRs19ccn9gkCUXsGx9MX9g7gpYWoY2Gaghc4cTqDk3XUGdVnsRYh3EvYHY/h1BPpEUgPcXXztiBlgy1AXjvlCwNz6U3j3n8H34DdVYWmGTciagAAAAASUVORK5CYII=";// tslint:disable
    }

    play(phrase: string): void {
        this.audio.pause();
        this.audio.src = `http://dict.youdao.com/dictvoice?audio=${phrase}&type=2`;
        this.audio.play();
    }

    render(): JSX.Element {
        return <div>
            <h1>My Vocabularies</h1>
            <ol>
                {
                    this.vocabularies.map((vocabulary) => {
                        return <li>
                            <span>{vocabulary}</span>
                            <a href="#" onClick={() => this.play(vocabulary)} onMouseOver={() => this.play(vocabulary)}><img src={this.icon}></img></a>
                        </li>;
                    })
                }
            </ol >
        </div >;
    }
}