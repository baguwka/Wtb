import React from 'react';
import './index.css';

class CurrencyTable extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            itemsInternal: props.items,
            itemsToShow: props.items,
            name: props.name
        }
    }

    onFilterChange(event){
        const {itemsInternal} = this.state;
        let filteredItems = itemsInternal;

        const code = event.target.value;
        const haveCode = code !== null && code.length > 0;
        if (haveCode)
        {
            filteredItems = itemsInternal.filter(i => i.code.toLowerCase().includes(code.toLowerCase()))
        }

        this.setState({
            itemsToShow: filteredItems
        });
    }

    render(){
        const {itemsToShow} = this.state;

        const rows = itemsToShow.map(item => (
            <tr key={item.id} data-code={item.code}>
                <td>{item.id}</td>
                <td>{item.name}</td>
                <td>{item.num}</td>
                <td>{item.code}</td>
                <td>{item.nominal}</td>
                <td>{item.value}</td>
            </tr>
            ));

        return(
            <div>
                <h3 className="heading">Курсы валют</h3>
                <label htmlFor="filter">Фильтрация по коду</label>
                <input id="filter" className="form-control" type="text" onChange={this.onFilterChange.bind(this)}/>
                <table className="table currency-table" id="currencies-table">
                    <thead>
                        <tr>
                            <th width="15%">Id</th>
                            <th width="53%">Имя</th>
                            <th>Num</th>
                            <th>Code</th>
                            <th>Номинал</th>
                            <th>Значение</th>
                        </tr>
                    </thead>
                    <tbody>
                        {rows}
                    </tbody>
                </table>
            </div>
        )
    }
}

export default CurrencyTable