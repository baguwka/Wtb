import React from 'react';
import ReactDOM from 'react-dom';
import Moment from 'moment';
import './index.css';
import CurrencyPairSelect from './CurrencyPair';
import CurrencyTable from './CurrencyTable';
import 'bootstrap/dist/css/bootstrap.css';

class App extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            error: null,
            date: null,
            items: [],
            isLoaded: false,
        };
    }

    componentDidMount(){
        fetch("/api/GetCurrency")
            .then(response => response.json())
            .then(result => {
                this.setState({
                    isLoaded: true,
                    items: result.currencies,
                    date: result.date,
                    name: result.name
                });
            },
            (error) => {
                this.setState({
                    isLoaded:true,
                    error
                });
            }
        )
    }
    
    render() {
        const {error, isLoaded, items, date, name} = this.state;

        if (error){
            return <div>Ошибка: {error.message}</div>;
        }
        else if (!isLoaded){
            return <div>Загрузка...</div>;
        }
        else{
            var dateFormatted = Moment(date).format("YYYY-MM-DD");
            return (
                <div className="container">
                    <div>
                        <h6>Информация актуальна на: {dateFormatted}</h6>
                    </div>

                    <CurrencyPairSelect items={items}/>
                    <CurrencyTable items={items} name={name}/>
                </div>
            );
        }
    }
}

// ========================================

ReactDOM.render(
  <App />,
  document.getElementById('root')
);
