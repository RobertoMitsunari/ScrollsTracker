function MangaItem(props) {
  // Desestruturar as props para um código mais limpo é uma boa prática.
  const { titulo, descricao, imagem, ultimoCapitulo } = props;

  return (
    // Container principal:
    // - 'flex': ativa o layout flexbox para alinhar os filhos lado a lado.
    // - 'gap-6': cria um espaçamento (gap) de 1.5rem entre a imagem e o texto.
    // - 'p-4': adiciona um preenchimento (padding) interno de 1rem.
    // - 'bg-white': define um fundo branco.
    // - 'rounded-lg': aplica bordas arredondadas grandes.
    // - 'shadow-md': adiciona uma sombra sutil para dar profundidade.
    // - 'border': adiciona uma borda fina.
    <div className="flex gap-6 p-4 m-3 bg-stone-900 rounded-lg shadow-md border border-indigo-900">
      {/* Container da Imagem (Esquerda) */}
      <div className="w-24 md:w-32 flex-shrink-0">
        {/* Imagem:
            - 'w-full h-full': faz a imagem ocupar todo o espaço do seu container.
            - 'object-cover': garante que a imagem cubra o espaço sem distorcer, cortando o excesso.
            - 'rounded-md': aplica bordas arredondadas médias.
        */}
        <img
          src={imagem}
          alt={`Capa de ${titulo}`}
          className="w-full h-full object-cover rounded-md"
        />
      </div>

      {/* Container do Texto (Direita) */}
      <div className="flex flex-col justify-center">
        {/* Título:
            - 'text-xl': aumenta o tamanho da fonte.
            - 'font-bold': deixa o texto em negrito.
            - 'text-gray-800': define uma cor de texto cinza escuro para boa legibilidade.
            - 'mb-1': adiciona uma pequena margem inferior (margin-bottom).
        */}
        <h2 className="text-xl font-bold text-white mb-1">{titulo}</h2>

        {/* Descrição:
            - 'text-gray-600': define uma cor de texto cinza mais clara.
            - 'text-sm': diminui o tamanho da fonte.
            - 'line-clamp-3': uma utilidade incrível que limita o texto a 3 linhas e adiciona "..." no final.
        */}
        <p className="text-white text-sm line-clamp-3 mb-1">{descricao}</p>
        <p className="text-white text-xl line-clamp-3">
          Ultimo Capítulo: {ultimoCapitulo}
        </p>
      </div>
    </div>
  );
}

export default MangaItem;
