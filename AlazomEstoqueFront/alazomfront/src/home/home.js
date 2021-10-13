import 'bootstrap/dist/css/bootstrap.min.css';
import '../style/style.css'
import req from '../servicos/req';
import React, { Component } from "react";
import { Button, Row, Col, Modal, Form } from 'react-bootstrap';
import Swal from 'sweetalert2';


export class Home extends Component {
    state = {
        placa: "",
        ativo1: false,
        ativo2: false,
        ativo3: false,
        show: false
    }

    handleClose = () => this.setState({ show: !this.state.show });


    cadastroCam = () => {
        const obj = {
            placa: this.state.placa,
        }

        req.enviarCadForn(obj).then(result => {
            if (result.data.statusCode === 200) {
                this.setState({ show: !this.state.show })

                req.alterarMaisVagas(true).then(result => {
                    if (result.data.statusCode === 200) {
                            this.setState({ativo1: !this.state.ativo1})
                    }
                })
                Swal.fire({
                    icon: 'success',
                    title: 'Ok!',
                    text: 'Fornecedor Cadastrado!',
                    allowOutsideClick: false
                });
            }
        }).catch(() => this.showModalCatch())
    }

    alterarVaga = (ativo, boleano) => {

        req.alterarMaisVagas(boleano).then(result => {

            console.log(result.data);
            if (result.data.statusCode = 200) {
                console.log(boleano, "boleano");
                debugger
                this.verificarAtivo(ativo, boleano);
                Swal.fire({
                    icon: 'success',
                    title: 'Ok!',
                    text: 'Vaga preenchida, descarregue!',
                    allowOutsideClick: false
                });
            }

        }).catch(() => {
            this.showModalCatch()
        })
    }

    showModalCatch = () => {
        Swal.fire({
            icon: 'warning',
            title: 'Erro de conexão, tente mais tarde!'
        })
    }
    verificarAtivo = (ativo, boleano) => {
        const { ativo1, ativo2, ativo3 } = this.state;

        switch (ativo) {
            case "ativo1":
                console.log("caindo aqui no ativo1", ativo1);
                this.setState({ ativo1: boleano });
                console.log("ativo1", ativo1);
            case "ativo2":
                console.log("caindo aqui no ativo2", ativo);
                this.state({ ativo2: boleano });
                console.log("ativo2", ativo2);
                break;
            case "ativo3":
                console.log("caindo aqui no ativo3", ativo);
                this.state({ ativo3: boleano });
                console.log("ativo3", ativo3);
                break;
        }
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
                    <Modal.Title>Fornecedor</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form>
                        <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
                            <Form.Label>Preencha o número da placa para ocupar a vaga</Form.Label>
                            <Form.Control type="text"
                                placeholder="Placa da carreta/caminhão"
                                onChange={(e) => this.setState({ placa: e.target.value })} />
                        </Form.Group>
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={this.handleClose}>
                        Fechar
                    </Button>
                    <Button variant="primary" onClick={this.cadastroCam}>Enviar</Button>
                </Modal.Footer>
            </Modal>
        )
    }

    render() {
        return (
            <div>
                <Row className="mx-0">
                    <Button as={Col} onClick={() => this.setState({ show: !this.state.show })} value={this.state.ativo1} variant={this.state.ativo1 ? "danger" : "success"}>Vaga 1</Button>
                    <Button as={Col} onClick={() => this.setState({ show: !this.state.show })} value={this.state.ativo2} variant={this.state.ativo2 ? "danger" : "success"} className="mx-2">Vaga 2</Button>
                    <Button as={Col} onClick={() => this.setState({ show: !this.state.show })} value={this.state.ativo3} variant={this.state.ativo3 ? "danger" : "success"}>Vaga 3</Button>
                </Row>
                {this.showModal()}
            </div>
        )
    }
}


export default Home;