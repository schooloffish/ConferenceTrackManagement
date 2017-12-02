import * as React from "react";
import * as ReactDOM from "react-dom";

export default class Phrase extends React.Component<{}, { showAddExample: boolean; showMeaning: boolean, showNext: boolean }> {
    audio: HTMLAudioElement;
    phrase: any;
    showMeaning = false;
    showNext = true;
    showAddExample = false;
    example = "";

    constructor(props: any) {
        super(props);
        this.phrase = {
            phrase: "test",
            phonetic: "haha",
            meaning: "yeah",
            sentences: ["1.xxx", "2.yyy"]
        };
        this.state = {
            showAddExample: this.showAddExample,
            showMeaning: this.showMeaning,
            showNext: this.showNext
        };
        this.audio = new Audio();
        this.play = this.play.bind(this);
        this.addExample = this.addExample.bind(this);
        this.next = this.next.bind(this);
        this.remember = this.remember.bind(this);
        this.forgot = this.forgot.bind(this);
    }

    next(): Boolean {
        return false;
    }
    play(e: any): void {

        e.preventDefault();
        this.audio.pause();
        this.audio.src = `http://dict.youdao.com/dictvoice?audio=${this.phrase.phrase}&type=2`;
        this.audio.play();
    }

    addExample(): void {

    }

    remember(): void {

    }

    forgot(): void {
        this.setState((previousState: any) => ({
            showMeaning: !previousState.showMeaning,
            showAddExample: !previousState.showAddExample,
            showNext: !previousState.showNext,

        }));
    }

    render() {
        return <div>
            <div >
                <h2 >{this.phrase.phrase}</h2>
                <h2 style={{ color: "gray", dispaly: "inline-block" }}>{this.phrase.phonetic}
                    <a href="#" onClick={this.play}>
                        <span>Click</span>
                    </a>
                </h2>
                <br />
                {this.state.showMeaning && <div>
                    {this.phrase.meaning}
                </div>}
                {this.state.showMeaning &&
                    <ul >
                        {this.phrase.sentences.map((sentence: string, index: number) => {
                            return <li key={index}>
                                {sentence}
                            </li>;
                        })}
                    </ul >
                }

                <div >
                    <div>
                        <button onClick={this.remember} >I remember</button>
                        <button onClick={this.forgot}>I forget</button>
                    </div>

                    {this.state.showNext && <h2 style={{ dispaly: "inline-block" }}>
                        <a href="#" onClick={this.next}>
                            <span>Next</span>
                        </a>
                    </h2 >}
                </div >

                <br />
                <br />
                {this.state.showAddExample && <div>
                    <textarea>{this.example}</textarea >
                    <br />
                    <button onClick={this.addExample}>add example to this phrase</button>
                </div>}
            </div>
        </div >;
    }
}