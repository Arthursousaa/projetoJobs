// --- BASE DE DADOS DAS VAGAS ---
/*const jobData = [
    {
        id: 1,
        title: "Desenvolvedor Full Stack Sênior",
        category: "tech",
        location: "São Paulo, BR (Híbrido)",
        tags: ["React", "Node.js", "Nova!"],
        tagClasses: ["tech", "tech", ""],
        description: "Liderar o design e implementação de novas funcionalidades no Front-end (React) e desenvolver e manter APIs RESTful robustas usando Node.js.",
        details: {
            responsibilities: [
                "Arquitetar soluções escaláveis.",
                "Mentorar desenvolvedores juniores e plenos.",
                "Garantir alta performance e qualidade de código."
            ],
            requirements: [
                "5+ anos de experiência Full Stack.",
                "Proficiência em JavaScript/TypeScript e React.",
                "Experiência com Node.js e serviços Cloud (AWS/Azure)."
            ]
        }
    },
    {
        id: 2,
        title: "UX/UI Designer Pleno",
        category: "design",
        location: "Remoto",
        tags: ["Figma", "UX Research", "Remoto"],
        tagClasses: ["design", "design", "remote"],
        description: "Transformar complexidade em interfaces intuitivas e belas, atuando da pesquisa inicial à entrega de protótipos de alta fidelidade.",
        details: {
            responsibilities: [
                "Conduzir testes de usabilidade e entrevistas.",
                "Criar protótipos interativos no Figma.",
                "Manter e evoluir o Design System."
            ],
            requirements: [
                "2+ anos de experiência em UX/UI.",
                "Domínio da ferramenta Figma.",
                "Portfólio com foco em processo de design."
            ]
        }
    },
    {
        id: 3,
        title: "Gerente de Contas B2B",
        category: "sales",
        location: "Rio de Janeiro, BR",
        tags: ["CRM", "Vendas", "B2B"],
        tagClasses: ["sales", "sales", "sales"],
        description: "Responsável por gerenciar e expandir a carteira de clientes B2B chave, fechando grandes contratos e mantendo relacionamentos duradouros.",
        details: {
            responsibilities: [
                "Identificar e qualificar novas oportunidades.",
                "Desenvolver e apresentar propostas comerciais.",
                "Negociar e fechar vendas B2B."
            ],
            requirements: [
                "3+ anos em vendas B2B.",
                "Histórico de metas superadas.",
                "Familiaridade com Salesforce ou HubSpot."
            ]
        }
    },
    {
        id: 4,
        title: "Engenheiro de Dados Júnior",
        category: "tech",
        location: "Remoto",
        tags: ["Python", "AWS", "Remoto"],
        tagClasses: ["tech", "tech", "remote"],
        description: "Colaborar na construção e manutenção de pipelines de dados eficientes, transformando dados brutos em insights valiosos.",
        details: {
            responsibilities: [
                "Desenvolver scripts de ETL/ELT em Python.",
                "Monitorar pipelines de dados.",
                "Documentar processos e governança."
            ],
            requirements: [
                "Conhecimento em Python e SQL.",
                "Familiaridade com AWS ou GCP.",
                "Conhecimento básico em Data Warehouse."
            ]
        }
    }
];

// --- INICIALIZAÇÃO E EVENTOS ---

document.addEventListener('DOMContentLoaded', () => {
    // 1. Renderiza a lista inicial
    renderJobCards(jobData);

    // 2. Adiciona evento ao botão de voltar
    document.getElementById('backToGridBtn').addEventListener('click', showJobListView);
    
    // 3. Configura todos os eventos dos botões globais
    setupGlobalButtonListeners();
});

function setupGlobalButtonListeners() {
    // 1. Botões de Autenticação (Simulação de Ação)
    document.getElementById('loginBtn').addEventListener('click', () => {
        alert('Função de Login acionada. (Simulação)');
        console.log('Login button clicked.');
    });
    
    document.getElementById('registerBtn').addEventListener('click', () => {
        alert('Função de Cadastro acionada. (Simulação)');
        console.log('Register button clicked.');
    });

    // 2. Botão de Busca (Simulação de Ação)
    document.getElementById('searchButton').addEventListener('click', () => {
        const searchTerm = document.getElementById('searchInput').value;
        if (searchTerm) {
            alert(`Executando busca por: "${searchTerm}". (Filtro de vagas não implementado).`);
        } else {
            alert('Por favor, digite um termo de busca.');
        }
        console.log('Search button clicked.');
    });
    
    // 3. Botão "Descubra Nossos Valores" (Simulação de Ação)
    document.getElementById('cultureBtn').addEventListener('click', () => {
        alert('Redirecionando para a página/seção "Nossa Cultura". (Simulação)');
        console.log('Culture CTA button clicked.');
    });
    
    // 4. Link "Ver Todas as Vagas" (Scrolla para o grid)
    document.getElementById('allJobsLink').addEventListener('click', (e) => {
        e.preventDefault();
        // Role a visualização para a lista de vagas
        document.getElementById('jobListView').scrollIntoView({ behavior: 'smooth' });
        console.log('All jobs link clicked, scrolling to list.');
    });
}

// --- FUNÇÕES DE RENDERIZAÇÃO E NAVEGAÇÃO ---

function renderJobCards(jobs) {
    const jobGrid = document.getElementById('jobGrid');
    jobGrid.innerHTML = jobs.map(job => createJobCardHTML(job)).join('');
    
    // Adiciona evento de clique em todos os links "Ver Vaga"
    document.querySelectorAll('.details-link').forEach(link => {
        link.addEventListener('click', (e) => {
            e.preventDefault(); 
            const jobId = parseInt(e.currentTarget.getAttribute('data-id'));
            openJobDetail(jobId);
        });
    });
}

function createJobCardHTML(job) {
    const tagsHTML = job.tags.map((tag, index) => 
        `<span class="tag ${job.tagClasses[index]}">${tag}</span>`
    ).join('');
    
    return `
        <div class="job-card" data-category="${job.category}" data-id="${job.id}">
            <h3>${job.title}</h3>
            <p class="location">${job.location}</p>
            <div class="tags-container">${tagsHTML}</div>
            <a href="#" class="details-link" data-id="${job.id}">Ver Vaga &rarr;</a>
        </div>
    `;
}

function createJobDetailHTML(job) {
    const tagsHTML = job.tags.map((tag, index) => 
        `<span class="tag ${job.tagClasses[index]}">${tag}</span>`
    ).join('');

    const respList = job.details.responsibilities.map(r => `<li>${r}</li>`).join('');
    const reqList = job.details.requirements.map(r => `<li>${r}</li>`).join('');

    // Adicionado a classe 'candidate-cta-btn' para anexar o listener
    return `
        <section class="job-detail-header">
            <h3 class="detail-title">${job.title}</h3>
            <p class="location">${job.location} | Tempo Integral</p>
            <div class="tags-container" style="margin-bottom: 20px;">${tagsHTML}</div>
            <button class="btn primary large-btn candidate-cta-btn">Candidatar-se Agora</button>
        </section>

        <section class="job-description-content" style="background-color: white; padding: 30px; border-radius: 8px; box-shadow: 0 2px 4px rgba(0,0,0,0.05);">
            
            <h3 style="color: var(--primary-color);">Sobre a Oportunidade</h3>
            <p>${job.description}</p>
            
            <h3 style="margin-top: 25px; color: var(--primary-color);">Responsabilidades Chave</h3>
            <ul style="list-style-type: square; margin-left: 20px;">${respList}</ul>

            <h3 style="margin-top: 25px; color: var(--primary-color);">Requisitos Mínimos</h3>
            <ul style="list-style-type: square; margin-left: 20px;">${reqList}</ul>
            
            <h3 style="margin-top: 25px; color: var(--primary-color);">O que oferecemos</h3>
            <p>Além de um ambiente colaborativo e desafiador, oferecemos:</p>
            <ul style="list-style-type: none; margin-left: 0;">
                <li>✅ Plano de Saúde Completo</li>
                <li>✅ Horários Flexíveis</li>
                <li>✅ Vale Refeição/Alimentação</li>
                <li>✅ Bônus por Performance Anual</li>
            </ul>

            <button class="btn primary large-btn candidate-cta-btn" style="margin-top: 30px;">Candidatar-se à Vaga</button>
        </section>
    `;
}

function openJobDetail(jobId) {
    const job = jobData.find(j => j.id === jobId);
    if (!job) return;

    // Injeta o conteúdo
    document.getElementById('jobDetailContent').innerHTML = createJobDetailHTML(job);

    // Esconde as seções de lista
    document.getElementById('heroSection').classList.add('hidden');
    document.getElementById('jobListView').classList.add('hidden');
    document.getElementById('cultureCta').classList.add('hidden');

    // Mostra a seção de detalhes
    document.getElementById('jobDetailContainer').classList.remove('hidden');

    // NOVO: Adiciona listener aos botões de candidatura após a injeção do HTML
    document.querySelectorAll('#jobDetailContent .candidate-cta-btn').forEach(btn => {
        btn.addEventListener('click', () => {
            alert(`Ação de Candidatura para a vaga: ${job.title} acionada! (Simulação)`);
            console.log(`Candidatura CTA for job ${job.id} clicked.`);
        });
    });

    // Scrolla para o topo
    window.scrollTo({ top: 0, behavior: 'smooth' });
}

function showJobListView() {
    // Esconde a seção de detalhes
    document.getElementById('jobDetailContainer').classList.add('hidden');

    // Mostra as seções de lista
    document.getElementById('heroSection').classList.remove('hidden');
    document.getElementById('jobListView').classList.remove('hidden');
    document.getElementById('cultureCta').classList.remove('hidden');

    window.scrollTo({ top: 0, behavior: 'smooth' });
}