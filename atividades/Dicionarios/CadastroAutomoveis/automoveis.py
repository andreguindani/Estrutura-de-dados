# Sistema de controle de automoveis usando dicionario
# Chave: placa | Valor: outro dicionario com os dados do carro

automoveis = {}


def mostrar(placa, carro):
    print(f"Placa:  {placa}")
    print(f"Marca:  {carro['marca']}")
    print(f"Modelo: {carro['modelo']}")
    print(f"Ano:    {carro['ano']}")
    print(f"Cor:    {carro['cor']}")
    print(f"Valor:  R$ {carro['valor']:.2f}")
    print("-" * 30)


def cadastrar():
    placa = input("Placa: ").strip().upper()
    if placa == "":
        print("A placa não pode ficar vazia.")
        return
    if placa in automoveis:
        print("Já existe um automóvel cadastrado com essa placa.")
        return

    marca = input("Marca: ").strip()
    modelo = input("Modelo: ").strip()
    try:
        ano = int(input("Ano: "))
        cor = input("Cor: ").strip()
        valor = float(input("Valor: R$ ").replace(",", "."))
    except ValueError:
        print("Ano ou valor inválido. Cadastro cancelado.")
        return

    automoveis[placa] = {
        "marca": marca,
        "modelo": modelo,
        "ano": ano,
        "cor": cor,
        "valor": valor,
    }
    print("Automóvel cadastrado com sucesso!")


def buscar_por_placa():
    placa = input("Placa: ").strip().upper()
    if placa in automoveis:
        mostrar(placa, automoveis[placa])
    else:
        print("Nenhum automóvel encontrado com essa placa.")


def listar():
    if len(automoveis) == 0:
        print("Nenhum automóvel cadastrado.")
        return
    for placa, carro in automoveis.items():
        mostrar(placa, carro)


def buscar_por_marca():
    marca = input("Marca: ").strip().lower()
    encontrou = False
    for placa, carro in automoveis.items():
        if carro["marca"].lower() == marca:
            mostrar(placa, carro)
            encontrou = True
    if not encontrou:
        print("Nenhum automóvel encontrado dessa marca.")


def main():
    while True:
        print()
        print("SISTEMA DE CONTROLE DE AUTOMÓVEIS")
        print()
        print("1 - Cadastrar automóvel")
        print("2 - Buscar automóvel pela placa")
        print("3 - Listar todos os automóveis")
        print("4 - Buscar automóveis por marca")
        print("5 - Sair")
        opcao = input("Escolha uma opção: ").strip()
        print()

        if opcao == "1":
            cadastrar()
        elif opcao == "2":
            buscar_por_placa()
        elif opcao == "3":
            listar()
        elif opcao == "4":
            buscar_por_marca()
        elif opcao == "5":
            print("Encerrando o programa...")
            break
        else:
            print("Opção inválida.")


main()
