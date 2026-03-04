#!/usr/bin/env python3
"""
GamesDev Factory - Sistema de Geração de Ideias
Data: 2026-03-04

Uso:
  python factory_ideas.py --market brasil --generate-ideas
  python factory_ideas.py --market indonesia --research
  python factory_ideas.py --select-top 3 --from ideias.json
"""

import os
import sys
import json
import requests
from datetime import datetime
from pathlib import Path

# Configuration
MARKETS_DIR = "mercados"
LLM_LOCAL_ENDPOINT = "http://localhost:11434/api/generate"
QWEN_API_URL = "https://coding-intl.dashscope.aliyuncs.com/v1/chat/completions"
QWEN_API_KEY = os.getenv("DASHSCOPE_API_KEY", "")

class Colors:
    GREEN = '\033[0;32m'
    YELLOW = '\033[1;33m'
    RED = '\033[0;31m'
    BLUE = '\033[0;34m'
    NC = '\033[0m'

def print_header(text):
    print(f"\n{Colors.GREEN}{'='*60}{Colors.NC}")
    print(f"{Colors.GREEN}{text.center(60)}{Colors.NC}")
    print(f"{Colors.GREEN}{'='*60}{Colors.NC}\n")

def print_info(text):
    print(f"{Colors.YELLOW}ℹ {text}{Colors.NC}")

def print_success(text):
    print(f"{Colors.GREEN}✓ {text}{Colors.NC}")

def print_error(text):
    print(f"{Colors.RED}✗ {text}{Colors.NC}")

def llm_local_generate(prompt, model="gemma3:4b"):
    """Generate text using local LLM (Ollama)"""
    print_info(f"Usando LLM Local ({model})...")
    
    payload = {
        "model": model,
        "prompt": prompt,
        "stream": False
    }
    
    try:
        response = requests.post(LLM_LOCAL_ENDPOINT, json=payload, timeout=120)
        response.raise_for_status()
        result = response.json()
        return result.get("response", "")
    except Exception as e:
        print_error(f"LLM Local error: {str(e)}")
        return None

def qwen_generate(prompt, model="qwen3.5-plus"):
    """Generate text using Qwen API"""
    print_info(f"Usando Qwen API ({model})...")
    
    headers = {
        "Authorization": f"Bearer {QWEN_API_KEY}",
        "Content-Type": "application/json"
    }
    
    payload = {
        "model": model,
        "messages": [
            {"role": "system", "content": "Você é um especialista em jogos mobile para mercados emergentes."},
            {"role": "user", "content": prompt}
        ],
        "temperature": 0.7,
        "max_tokens": 4000
    }
    
    try:
        response = requests.post(QWEN_API_URL, headers=headers, json=payload, timeout=120)
        response.raise_for_status()
        result = response.json()
        return result["choices"][0]["message"]["content"]
    except Exception as e:
        print_error(f"Qwen API error: {str(e)}")
        return None

def research_market(market_name):
    """Research a market using LLM Local"""
    print_header(f"Pesquisa de Mercado: {market_name}")
    
    prompt = f"""
Você é um analista de mercado de jogos mobile.

Analise o mercado de jogos mobile em {market_name} considerando:

1. DEMOGRAFIA
   - População total
   - Usuários de smartphone
   - Faixa etária predominante
   - Renda média

2. CULTURA DE JOGOS
   - Gêneros mais populares
   - Jogos de sucesso local
   - Preferências de gameplay
   - Tempo médio de sessão

3. CULTURA LOCAL
   - Festivais principais
   - Esportes populares
   - Símbolos culturais
   - Cores preferidas

4. MONETIZAÇÃO
   - Métodos de pagamento
   - Ticket médio de IAP
   - Tolerância a ads
   - eCPM local

5. REGULAMENTAÇÃO
   - Leis de jogos
   - Restrições de conteúdo
   - Age rating
   - Taxas/impostos

Output: JSON estruturado com todos os dados.
Seja específico e use dados reais quando possível.
"""
    
    result = llm_local_generate(prompt)
    
    if result:
        # Save to file
        market_dir = Path(MARKETS_DIR) / market_name.lower()
        market_dir.mkdir(parents=True, exist_ok=True)
        
        output_file = market_dir / "pesquisa_mercado.json"
        with open(output_file, 'w', encoding='utf-8') as f:
            f.write(result)
        
        print_success(f"Pesquisa salva em: {output_file}")
        return result
    else:
        print_error("Falha na pesquisa de mercado")
        return None

def generate_ideas(market_name, research_data=None):
    """Generate game ideas using Qwen API"""
    print_header(f"Geração de Ideias: {market_name}")
    
    prompt = f"""
Com base na pesquisa de mercado de {market_name}, gere 20 ideias de jogos mobile.

Para cada ideia inclua:

1. NOME E CONCEITO
   - Nome em inglês + nome local
   - Elevator pitch (1 frase)
   - Gênero principal

2. GAMEPLAY
   - Mecânica core
   - Duração da sessão
   - Single/Multiplayer
   - Progressão

3. LOCALIZAÇÃO
   - Tema cultural específico
   - Festivais/eventos
   - Elementos locais
   - Idiomas necessários

4. MONETIZAÇÃO
   - Estratégia (Ads, IAP, misto)
   - Preço de IAP (moeda local)
   - Placement de ads
   - Rewards

5. DESENVOLVIMENTO
   - Complexidade (1-5, onde 1=muito fácil)
   - Tempo estimado (dias)
   - % Reuse de código existente (GamesDev India)
   - Assets novos necessários

6. POTENCIAL
   - Download projections (D1, D7, D30)
   - Revenue projections (D30)
   - KPI targets (retention, ARPDAU)
   - Riscos principais

Critérios de prioridade:
✅ Baixa complexidade (1-3)
✅ Alto reuse de código (>60%)
✅ Tema cultural forte
✅ Monetização adaptada ao mercado
✅ Potencial de viralização

Output: JSON array com exatamente 20 ideias.
"""
    
    if research_data:
        prompt += f"\n\nDados da pesquisa:\n{research_data}"
    
    result = qwen_generate(prompt)
    
    if result:
        # Save to file
        market_dir = Path(MARKETS_DIR) / market_name.lower()
        market_dir.mkdir(parents=True, exist_ok=True)
        
        output_file = market_dir / "ideias_qwen.json"
        with open(output_file, 'w', encoding='utf-8') as f:
            f.write(result)
        
        print_success(f"Ideias salvas em: {output_file}")
        return result
    else:
        print_error("Falha na geração de ideias")
        return None

def select_top_ideas(ideas_file, top_n=3):
    """Select top N ideas using LLM Local"""
    print_header(f"Selecionando Top {top_n} Ideias")
    
    # Load ideas
    with open(ideas_file, 'r', encoding='utf-8') as f:
        ideas = json.load(f)
    
    print_info(f"{len(ideas)} ideias carregadas")
    
    prompt = f"""
Selecione as {top_n} melhores ideias para desenvolvimento imediato.

Critérios de seleção (peso):
1. Baixa complexidade (peso: 30%) - Prefira 1-3
2. Alto reuse de código (peso: 25%) - Prefira >60%
3. Tema cultural forte (peso: 20%)
4. Potencial de monetização (peso: 15%)
5. Diferencial competitivo (peso: 10%)

Para cada ideia selecionada, forneça:
- Nome do jogo
- Justificativa da seleção (2-3 frases)
- Riscos principais
- Assets novos necessários
- Similar com jogos existentes (concorrência)
- Score final (0-100)

Ideias disponíveis:
{json.dumps(ideas, ensure_ascii=False)[:5000]}

Output: JSON array com top {top_n} ideias ranqueadas.
"""
    
    result = llm_local_generate(prompt)
    
    if result:
        # Save to file
        output_file = ideas_file.parent / f"top{top_n}_selecionadas.json"
        with open(output_file, 'w', encoding='utf-8') as f:
            f.write(result)
        
        print_success(f"Top {top_n} salvas em: {output_file}")
        return result
    else:
        print_error("Falha na seleção")
        return None

def generate_gdd(game_idea, market_name):
    """Generate full GDD from idea"""
    print_header(f"Geração de GDD: {game_idea.get('name', 'Jogo')}")
    
    prompt = f"""
Com base nesta ideia de jogo, gere um Game Design Document (GDD) completo.

Ideia:
{json.dumps(game_idea, ensure_ascii=False)}

O GDD deve incluir:

1. VISÃO GERAL
   - Nome do jogo
   - Gênero
   - Target audience
   - Plataforma
   - Tema

2. GAMEPLAY
   - Mecânicas principais
   - Controles
   - Progressão
   - Duração da sessão

3. FEATURES
   - Lista completa de features
   - Prioridade (MVP vs Post-Launch)

4. MONETIZAÇÃO
   - Estratégia detalhada
   - Preços de IAP (moeda local)
   - Ad placements
   - Rewards

5. ARQUITETURA TÉCNICA
   - Stack tecnológica
   - Reuse de código existente
   - Código novo necessário
   - Assets necessários

6. CRONOGRAMA
   - Tempo estimado (dias)
   - Milestones
   - Dependências

7. KPI TARGETS
   - Downloads (D1, D7, D30)
   - Retention (D1, D7, D30)
   - ARPDAU
   - Revenue projections

8. RISCOS E MITIGAÇÃO
   - Riscos principais
   - Plano de mitigação

Output: Markdown formatado, completo e detalhado.
"""
    
    result = qwen_generate(prompt, model="qwen3.5-plus")
    
    if result:
        market_dir = Path(MARKETS_DIR) / market_name.lower()
        output_file = market_dir / f"gdd_{game_idea.get('id', 'game')}.md"
        with open(output_file, 'w', encoding='utf-8') as f:
            f.write(result)
        
        print_success(f"GDD salvo em: {output_file}")
        return result
    else:
        print_error("Falha na geração do GDD")
        return None

def main():
    import argparse
    
    parser = argparse.ArgumentParser(description='GamesDev Factory - Sistema de Ideias')
    parser.add_argument('--market', type=str, help='Market name (e.g., brasil, indonesia)')
    parser.add_argument('--research', action='store_true', help='Research market')
    parser.add_argument('--generate-ideas', action='store_true', help='Generate game ideas')
    parser.add_argument('--select-top', type=int, help='Select top N ideas')
    parser.add_argument('--from', dest='ideas_file', type=str, help='Ideas file to select from')
    parser.add_argument('--generate-gdd', action='store_true', help='Generate full GDD')
    parser.add_argument('--game-id', type=str, help='Game ID for GDD generation')
    
    args = parser.parse_args()
    
    print_header("GamesDev Factory - Sistema de Geração de Ideias")
    
    if not args.market:
        parser.print_help()
        return 1
    
    # Research market
    if args.research:
        research_data = research_market(args.market)
        if research_data:
            print_success(f"Pesquisa de {args.market} concluída!")
    
    # Generate ideas
    if args.generate_ideas:
        research_file = Path(MARKETS_DIR) / args.market.lower() / "pesquisa_mercado.json"
        research_data = None
        
        if research_file.exists():
            with open(research_file, 'r', encoding='utf-8') as f:
                research_data = f.read()
        
        ideas = generate_ideas(args.market, research_data)
        if ideas:
            print_success(f"Ideias para {args.market} geradas!")
    
    # Select top ideas
    if args.select_top:
        if not args.ideas_file:
            args.ideas_file = Path(MARKETS_DIR) / args.market.lower() / "ideias_qwen.json"
        
        select_top_ideas(Path(args.ideas_file), args.select_top)
    
    # Generate GDD
    if args.generate_gdd:
        if not args.game_id:
            print_error("Game ID required for GDD generation")
            return 1
        
        # Load selected ideas
        ideas_file = Path(MARKETS_DIR) / args.market.lower() / f"top{args.select_top or 3}_selecionadas.json"
        
        if ideas_file.exists():
            with open(ideas_file, 'r', encoding='utf-8') as f:
                ideas = json.load(f)
            
            game_idea = next((g for g in ideas if g.get('id') == args.game_id), None)
            
            if game_idea:
                generate_gdd(game_idea, args.market)
            else:
                print_error(f"Game ID not found: {args.game_id}")
        else:
            print_error(f"Ideas file not found: {ideas_file}")
    
    return 0

if __name__ == '__main__':
    sys.exit(main())
