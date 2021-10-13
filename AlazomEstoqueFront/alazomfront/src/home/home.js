import 'bootstrap/dist/css/bootstrap.min.css';
import '../style/style.css'
import req from '../servicos/req';
import React, { Component } from "react";
import { Button, Row, Col, Modal } from 'react-bootstrap';


export class Home extends Component {
    state = {
        ativo1: true,
        ativo2: true,
        ativo3: true,
        show: false
    }

    handleClose = () => this.setState({ show: !this.state.show });

    alterarVaga = () => {

        req.alterarMaisVagas(true).then(result => {

            if (result.data)
                this.setState({ ativo1: false })

        }).catch(() => {

        })
    }

    showModal = () => {
        return (
            <Modal
                show={this.state.show}
                onHide={this.handleClose}
                backdrop="static"
                keyboard={false}
            >
                <Modal.Header closeButton>
                    <Modal.Title>Modal title</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    I will not close if you click outside me. Don't even try to press
                    escape key.
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={this.handleClose}>
                        Close
                    </Button>
                    <Button variant="primary">Understood</Button>
                </Modal.Footer>
            </Modal>
        )
    }

    render() {
        return (
            <div>
                <Row className="mx-0">
                    <Button as={Col} onClick={this.alterarVaga} variant={this.state.ativo ? "success" : "danger"}>Vaga 1</Button>
                    <Button as={Col} variant={this.state.ativo2 ? "success" : "danger"} className="mx-2">Vaga 2</Button>
                    <Button as={Col} variant={this.state.ativo3 ? "success" : "danger"}>Vaga 3</Button>
                </Row>
            </div>
        )
    }
}


export default Home;