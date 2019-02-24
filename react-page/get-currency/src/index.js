import React from 'react';
import ReactDOM from 'react-dom';

class CurrencyTable extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            items: []
        };
    }

    componentDidMount(){
        fetch("/api/GetCurrency")
            .then(response => response.json())
            .then(result => {
                this.setState({
                    isLoaded: true,
                    items: result.currencies
                })
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
        const {error, isLoaded, items} = this.state;
        if (error){
            return <div>Error: {error.message}</div>;
        }
        else if (!isLoaded){
            return <div>Loading...</div>;
        }
        else{
            return (
                <ul>
                    {items.map(item => (
                        <li key={item.id}>
                            {item.code} {item.value}
                        </li>
                    ))}
                </ul>
            );
        }
    }
}

// ========================================

ReactDOM.render(
  <CurrencyTable />,
  document.getElementById('root')
);
