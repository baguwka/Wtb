import React from 'react';
import './index.css';

class CurrencyPairSelect extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            items: props.items,
            pair_1_selected: props.items.find(i => i.code === "EUR"),
            pair_2_selected: props.items.find(i => i.code === "USD"),
        }
    }

    onPair_1Change = (event) => {
        const item = this.getItemById(event.target.value)
        this.setState({ pair_1_selected: item });
    };

    onPair_2Change = (event) => {
        const item = this.getItemById(event.target.value)
        this.setState({ pair_2_selected: item });

    };

    getItemById(id){
        const { items } = this.state;
        return items.find(el => el.id === id);
    }

    render(){
        const {pair_1_selected, pair_2_selected, items} = this.state;
        const pairValue = pair_1_selected.value / pair_2_selected.value;

        return (
            <div>
                <h3 className="heading">Валютная пара</h3>
                <select id="pair_1" 
                    defaultValue={pair_1_selected.id}
                    onChange={this.onPair_1Change.bind(this)}>
                    {items.map(item => (
                        <option key={item.id} value={item.id}>{item.name}</option>    
                    ))}
                </select>
                <select id="pair_2" 
                    defaultValue={pair_2_selected.id}
                    onChange={this.onPair_2Change.bind(this)}>
                    {items.map(item => (
                        <option key={item.id} value={item.id}>{item.name}</option>    
                    ))}
                </select>
                <div>
                    <span>{pairValue}</span>
                </div>
            </div>
        );
    }
}

export default CurrencyPairSelect