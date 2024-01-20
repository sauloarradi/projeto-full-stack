# Projeto Web API para base de dados de Super Heróis

Neste projeto foi criada uma WEB API robusta utilizando **C#, .NET 6, Entity Framework Core e SQL Server**. Foi explorada a implementação de um CRUD completo, aplicado o padrão Repository para organização do código e otimizado a performance com chamadas assíncronas usando async/await.

Com base em conceitos fundamentais necessários para construir uma API poderosa e escalável, foi estabelecida a conexão com o banco de dados, criada as operações de CRUD e separada a camada de acesso a dados do restante da lógica do negócio.

Essa WEB API foi desenvolvida utilizando boas práticas, assim sendo não foi colocado todo raciocínio, toda lógica dentro do controller, que não é o que habitualmente é feito, isso porque é uma má prática a gente ter fat controller. Para isso foram criados serviços que serão responsaveis por se comunicar com o banco, eles irão pegar os dados do banco e o controller basicamente irá consultar o serviço e mostra-lo para o usuário. Esse padrão é chamado de Repository Pattern.
