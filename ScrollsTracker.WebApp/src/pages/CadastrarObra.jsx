import React from 'react';

function CadastrarObra() {
  return (
    // Container principal: fundo cinza-escuro
    <div className="min-h-screen bg-gray-900 flex items-center justify-center p-4">
      
      {/* Formulário: fundo mais escuro, com bordas sutis para contraste */}
      <form className="w-full max-w-lg bg-gray-800 p-8 rounded-lg shadow-md border border-gray-700">

        <h2 className="text-2xl font-bold text-white mb-6 text-center">
          Cadastrar Nova Obra
        </h2>

        {/* Container para os campos do formulário */}
        <div className="grid grid-cols-1 gap-6">

          {/* Campo Título */}
          <div>
            <label htmlFor="titulo" className="block text-sm font-medium text-gray-300 mb-1">
              Título
            </label>
            <input
              type="text"
              id="titulo"
              name="titulo"
              className="block w-full px-3 py-2 bg-gray-700 border border-gray-600 rounded-md shadow-sm text-white placeholder-gray-400 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
              placeholder="Ex: One Piece"
            />
          </div>

          {/* Campo Descrição */}
          <div>
            <label htmlFor="descricao" className="block text-sm font-medium text-gray-300 mb-1">
              Descrição
            </label>
            <textarea
              id="descricao"
              name="descricao"
              rows="3"
              className="block w-full px-3 py-2 bg-gray-700 border border-gray-600 rounded-md shadow-sm text-white placeholder-gray-400 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
              placeholder="Uma breve descrição da obra..."
            ></textarea>
          </div>

          {/* Campo Imagem (URL) */}
          <div>
            <label htmlFor="imagem" className="block text-sm font-medium text-gray-300 mb-1">
              URL da Imagem de Capa
            </label>
            <input
              type="text"
              id="imagem"
              name="imagem"
              className="block w-full px-3 py-2 bg-gray-700 border border-gray-600 rounded-md shadow-sm text-white placeholder-gray-400 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
              placeholder="https://exemplo.com/capa.jpg"
            />
          </div>

          {/* Grid para os campos numéricos */}
          <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
            {/* Campo Total de Capítulos */}
            <div>
              <label htmlFor="totalCapitulos" className="block text-sm font-medium text-gray-300 mb-1">
                Total de Capítulos
              </label>
              <input
                type="number"
                id="totalCapitulos"
                name="totalCapitulos"
                className="block w-full px-3 py-2 bg-gray-700 border border-gray-600 rounded-md shadow-sm text-white placeholder-gray-400 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
                placeholder="1100"
              />
            </div>

            {/* Campo Último Capítulo Lido */}
            <div>
              <label htmlFor="ultimoCapituloLido" className="block text-sm font-medium text-gray-300 mb-1">
                Último Capítulo Lido
              </label>
              <input
                type="number"
                id="ultimoCapituloLido"
                name="ultimoCapituloLido"
                className="block w-full px-3 py-2 bg-gray-700 border border-gray-600 rounded-md shadow-sm text-white placeholder-gray-400 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
                placeholder="1050"
              />
            </div>
          </div>
          
          {/* Campo Status */}
          <div>
            <label htmlFor="status" className="block text-sm font-medium text-gray-300 mb-1">
              Status
            </label>
            <select
              id="status"
              name="status"
              className="block w-full px-3 py-2 bg-gray-700 border border-gray-600 rounded-md shadow-sm text-white focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
            >
              <option className="bg-gray-700 text-white">Lendo</option>
              <option className="bg-gray-700 text-white">Completo</option>
              <option className="bg-gray-700 text-white">Planejo Ler</option>
              <option className="bg-gray-700 text-white">Pausado</option>
              <option className="bg-gray-700 text-white">Abandonado</option>
            </select>
          </div>

          {/* Botão de Envio */}
          <div className="mt-4">
            <button
              type="submit"
              className="w-full flex justify-center py-2 px-4 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
            >
              Cadastrar Obra
            </button>
          </div>

        </div>
      </form>
    </div>
  );
}

export default CadastrarObra;
