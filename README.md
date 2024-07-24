# SistemaCondominio


import static org.mockito.Mockito.*;
import static org.junit.Assert.*;
import static org.hamcrest.CoreMatchers.*;

import java.util.*;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;

import org.json.JSONObject;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.*;
import org.mockito.junit.MockitoJUnitRunner;

@RunWith(MockitoJUnitRunner.class)
public class MyClassTest {

    @Mock
    private HttpServletRequest request;
    @Mock
    private HttpSession session;
    @Mock
    private PfAgentlessHelper pfAgentlessHelper;
    @Mock
    private HybridFlowRedirectToClientService hybridFlowRedirectToClientService;

    @InjectMocks
    private MyClass myClass;

    @Before
    public void setUp() {
        when(request.getSession()).thenReturn(session);
    }

    @Test
    public void testDenyRequest() throws Exception {
        // Mock session attributes
        when(session.getAttribute("SESSION_REDIRECT_BASE_URL")).thenReturn("http://base.url/");
        when(session.getAttribute("SESSION_DROPOFF_ENDPOINT")).thenReturn("http://dropoff.url/");
        when(session.getAttribute("CLIENT_LOGO_URL")).thenReturn("http://logo.url/");
        when(session.getAttribute("DEFINITION_ID")).thenReturn("someDefinitionId");
        when(session.getAttribute("HANDOFF")).thenReturn(false);
        ReferenceResponse pickupObject = mock(ReferenceResponse.class);
        when(session.getAttribute("SESSION_LAST_PICKUP_RESULT")).thenReturn(pickupObject);
        Customer customer = mock(Customer.class);
        when(session.getAttribute("CUSTOMER")).thenReturn(customer);
        ConsentDirectory consentDirectory = mock(ConsentDirectory.class);
        when(session.getAttribute("CONSENT_DIRECTORY")).thenReturn(consentDirectory);
        
        String resumePath = "/resume";
        
        // Mock method calls
        when(pfAgentlessHelper.dropoffRef(anyString(), any(JSONObject.class))).thenReturn("refId");

        // Call the method
        String result = myClass.denyRequest(request, resumePath);

        // Verify interactions and assertions
        verify(session).setAttribute("DECISION_FLAG_ALLOW", false);
        verify(session).setAttribute("CLIENT_LOGO_URL", "http://logo.url/");
        verify(session).setAttribute("REFRESH_URL", "http://base.url/resume?ref=refId");

        assertThat(result, is(ModalDenyRedirectEnum.getModal("someDefinitionId")));
    }
}

Sistema de Controle de Acesso para Condomínios

O Sistema desenvolvido se baseia na elaboração de um software de controle de acesso para condomínios na linguagem .NET estudada na disciplina de Linguagem de Programação 4. 

Em segurança, especialmente segurança física, o termo controle de acesso é uma referência à prática de permitir o acesso a uma propriedade, apenas para pessoas autorizadas, e são tecnologias que restringem tal acesso, tentando garantir a segurança de pessoas e bens e impedindo o fluxo de indivíduos não-autorizados.

Tendo em vista o exposto acima, realizamos a criação de CRUDs (criação, consulta, atualização e deleção) para o cadastro de condôminos, veículos, visitantes e funcionários de um condomínio para gerenciamento da movimentação (entrada e saída) de pessoas nas áreas internas de um condomínio.

O cadastro conta com campos para dados pessoais como Nome Completo, CPF, Número do Apartamento, Telefone e Foto, permitindo assim maior rastreabilidade em casos de necessidade.

Trata-se de um sistema para uso do administrativo de um condomínio, e tem como objetivo promover a segurança em relação ao tráfego de pessoas através da obtenção de dados dos mesmos.

Nosso sistema oferece a possibilidade de cadastros completos (e com upload de imagens) permitindo rápida identificação e maior qualidade no controle do acesso.

Equipe:

Dilan Campos de Lima (SP3013359)
Fabricio Teixeira da Silva (SP3013472)
Mateus Santana Joaquim (SP3014266)
Ramon Souza de Oliveira (SP3013367)
Yasmin Cordeiro Assis (SP3021645)
