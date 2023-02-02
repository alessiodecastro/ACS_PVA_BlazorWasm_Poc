import './webchatComposite.js';
import 'https://code.jquery.com/jquery-1.12.4.js'
import 'https://code.jquery.com/ui/1.12.1/jquery-ui.js'



export function loadWebChatComposite(element) {
    return (async function () {

        const res = await fetch('https://ced36af1b92ee6ae99db50a8734a78.5a.environment.api.powerplatform.com/powervirtualagents/bots/91ba69f0-45e8-4015-a901-723bd9123c5b/directline/token?api-version=2022-03-01-preview', { method: 'GET' });
        const { token } = await res.json();

        const store = window.WebChat.createStore({}, ({ dispatch }) => next => action => {
            if (action.type === 'DIRECT_LINE/INCOMING_ACTIVITY') {

                //just for demo/PoC purposes - to improve the mechanism for production
                if (action.payload.activity.from.role = "bot" && action.payload.activity.text.includes("Please wait the starting call on the screen...")) {
                    const event = new Event('startSupportCall');

                    event.data = action.payload.activity;
                    window.dispatchEvent(event);
                }
            }

            return next(action);
        });


        window.WebChat.renderWebChat(
            {
                directLine: window.WebChat.createDirectLine({
                    token: token,
                    domain: 'https://europe.directline.botframework.com/v3/directline'
                }),
                store
            },
            element
        );

        window.addEventListener('startSupportCall', ({ data }) => {
            console.log(`Received an activity of type "${data.type}":`);
            console.log(data);

            DotNet.invokeMethodAsync('ACS_PVA_BlazorWasm_Poc.Client', 'renderVideoCall', 'idCalltest')
                .then(data => {
                    console.log(data);
                });

        });

        element.focus();

        const chatbox = jQuery.noConflict();

        chatbox(() => {
            chatbox(".chatbox-open").click(() => {
                chatbox(".chatbox-popup, .chatbox-close").show();
                chatbox(".pulsating-circle").hide();
                chatbox(".chatbox-open").hide();
                chatbox(".draggable").draggable({
                    cancel: '.webchat', create: function (event, ui) {
                        chatbox(this).css({
                            top: chatbox(this).position().top,
                            bottom: "auto"
                        });
                    }
                });
            });

            chatbox(".chatbox-close").click(() => {
                chatbox(".chatbox-popup, .chatbox-close").hide();
                chatbox(".pulsating-circle").show();
                chatbox(".chatbox-open").show();
            });

            chatbox(".chatbox-maximize").click(() => {
                chatbox(".draggable").draggable('destroy');

                chatbox('.chatbox-popup').addClass('chatbox-panel').removeClass('chatbox-popup');
                chatbox('.chatbox-popup__header').addClass('chatbox-panel__header').removeClass('chatbox-popup__header');
                chatbox('.chatbox-popup__main').addClass('chatbox-panel__main').removeClass('chatbox-popup__main');
                // chatbox('.chatbox-panel-close').show();
                chatbox('.chatbox-minimize').show();
                chatbox('.chatbox-maximize').hide();
                chatbox('#header-avatar').css('flex', '1');
            });

            chatbox(".chatbox-minimize").click(() => {
                chatbox(".draggable").draggable({
                    cancel: '#webchat', create: function (event, ui) {
                        chatbox(this).css({
                            right: "16px",
                            bottom: "auto"
                        });
                    }
                });

                chatbox('.chatbox-panel').addClass('chatbox-popup').removeClass('chatbox-panel');
                chatbox('.chatbox-panel__header').addClass('chatbox-popup__header').removeClass('chatbox-panel__header');
                chatbox('.chatbox-panel__main').addClass('chatbox-popup__main').removeClass('chatbox-panel__main');
                // chatbox('.chatbox-panel-close').hide();
                chatbox('.chatbox-minimize').hide();
                chatbox('.chatbox-maximize').show();
                chatbox('#header-avatar').css('flex', '2');
            });

            chatbox(".chatbox-panel-close").click(() => {
                chatbox('.chatbox-panel').addClass('chatbox-popup').removeClass('chatbox-panel');
                chatbox('.chatbox-panel__header').addClass('chatbox-popup__header').removeClass('chatbox-panel__header');
                chatbox('.chatbox-panel__main').addClass('chatbox-popup__main').removeClass('chatbox-panel__main');
                // chatbox('.chatbox-panel-close').hide();
                chatbox('.chatbox-minimize').hide();
                chatbox('.chatbox-maximize').show();
                chatbox(".chatbox-popup, .chatbox-close").hide();
                chatbox(".pulsating-circle").show();
                chatbox(".chatbox-open").show();
                chatbox('#header-avatar').css('flex', '2');
            });


            chatbox('.js-messageClose').on('click', function (e) {
                chatbox('.webchat').show();
                chatbox(this).closest('.alert').hide();
            });

        });

    })().catch(err => console.error(err));
}

