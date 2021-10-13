import 'bootstrap/dist/css/bootstrap.min.css';
import '../style/style.css'
import req from '../servicos/req';
import React, { Component } from "react";
import { Button, Row, Col } from 'react-bootstrap';


export class Home extends Component {
    state = {
        ativo: true
    }

    alterarVaga = () => {
        const { ativo } = this.state;

        req.alterarMaisVagas(true).then(result => 
            console.log(result.data))
    }
    render() {
        return (
            <div>
                <Row className="mx-0">
                    <Button as={Col} onClick={this.alterarVaga} variant={this.state.ativo = this.state.ativo ? "success" : "danger"}>Vaga 1</Button>
                    <Button as={Col} variant={this.state.ativo = this.state.ativo ? "success" : "danger"} className="mx-2">Vaga 2</Button>
                    <Button as={Col} variant={this.state.ativo = this.state.ativo ? "success" : "danger"}>Vaga 3</Button>
                </Row>
            </div>
        )
    }
}


export default Home;